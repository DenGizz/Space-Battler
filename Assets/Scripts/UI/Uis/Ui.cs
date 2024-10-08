using System;
using System.Collections.Generic;
using Assets.Scripts.UI.UiScreens;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Uis
{
    public class Ui : MonoBehaviour, IInitializable, IGameStateChangeEventSource
    {
        private Dictionary<Type, UiScreen> _screens;
        private UiScreen _currentScreen;
        public event Action<GameStateChangeEvent> OnGameStateChangeEvent;

        private bool _isInitialized;

        public T GetScreen<T>() where T : UiScreen
        {
            if (!_isInitialized)
                throw new Exception("Ui is not initialized");

            return (T)_screens[typeof(T)] ?? throw new Exception($"Screen of type {typeof(T)} not found");
        }

        public T GoToScreen<T>() where T : UiScreen
        {
            if (!_isInitialized)
                throw new Exception("Ui is not initialized");

            T screen = (T)_screens[typeof(T)];

            if(_currentScreen != null )
                _currentScreen.Hide();

            if (_currentScreen != null && _currentScreen is IGameStateChangeEventSource eventSourceScreen)
                eventSourceScreen.OnGameStateChangeEvent -= OnCurrentScreenGameStateChangeEventHandler;

            if (screen is IGameStateChangeEventSource eventSource)
                eventSource.OnGameStateChangeEvent += OnCurrentScreenGameStateChangeEventHandler;

            if (!screen.IsInitialized)
                throw new Exception("Screen is not initialized");

            // Code to go to screen
            screen.Show();
            _currentScreen = screen;
            return screen;
        }

        public void Initialize()
        {
            _screens = new Dictionary<Type, UiScreen>();
            var screens = GetComponentsInChildren<UiScreen>();

            foreach (var screen in screens)
            {
                _screens.Add(screen.GetType(), screen);
                screen.Setup(this);
                screen.Hide();
            }

            _isInitialized = true;
        }

        private void OnCurrentScreenGameStateChangeEventHandler(GameStateChangeEvent @event)
        {
            OnGameStateChangeEvent?.Invoke(@event);
        }
    }
}
