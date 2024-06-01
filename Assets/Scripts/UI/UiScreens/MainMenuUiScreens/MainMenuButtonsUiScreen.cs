using System;
using Assets.Scripts.UI.Uis;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.UiScreens.MainMenuUiScreens
{
    public class MainMenuButtonsUiScreen : UiScreen, IGameStateChangeEventSource
    {
        [SerializeField] private Button _playStoryModeButton;
        [SerializeField] private Button _playSandBoxModeButton;

        public event Action<GameStateChangeEvent> OnGameStateChangeEvent;

        public override void Setup(Ui ui)
        {
            base.Setup(ui);

            _playStoryModeButton.onClick.AddListener(OnPlayStoryModeButtonClicked);
            _playSandBoxModeButton.onClick.AddListener(OnPlaySandBoxModeButtonClicked);
        }

        private void OnPlayStoryModeButtonClicked()
        {
            OnGameStateChangeEvent?.Invoke(GameStateChangeEvent.EnterStoryMode);
        }

        private void OnPlaySandBoxModeButtonClicked()
        {
            OnGameStateChangeEvent?.Invoke(GameStateChangeEvent.EnterSandboxMode);
        }
    }
}
