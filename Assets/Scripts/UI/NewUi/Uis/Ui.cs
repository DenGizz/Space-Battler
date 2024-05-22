using Assets.Scripts.UI.NewUi.Uis;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Ui : MonoBehaviour, IInitializable, IGameStateChangeEventSource
{
    private Dictionary<Type, UiScreen> _screens;
    private UiScreen _currentScreen;
    public event Action<GameStateChangeEvent> OnGameStateChangeEvent;

    public T GoToScreen<T>() where T : UiScreen
    {
        T screen = (T)_screens[typeof(T)];

        if(screen != null )
        {
            screen.Hide();
        }

        if (_currentScreen != null && _currentScreen is IGameStateChangeEventSource eventSourceScreen)
            eventSourceScreen.OnGameStateChangeEvent -= OnGameStateChangeEvent.Invoke;

        if (screen is IGameStateChangeEventSource eventSource)
            eventSource.OnGameStateChangeEvent += OnGameStateChangeEvent.Invoke;

        if (!screen.IsInitialized)
            throw new Exception("Screen is not initialized");

        // Code to go to screen
        screen.Show();
        _currentScreen = screen;
        return screen;
    }

    public void Initialize()
    {
        var screens = GetComponentsInChildren<UiScreen>();

        foreach (var screen in screens)
        {
            _screens.Add(screen.GetType(), screen);
            screen.Setup(this);
        }
    }
}
