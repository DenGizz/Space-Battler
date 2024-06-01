using System;
using Assets.Scripts.UI.Uis;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.UiScreens.SandboxModeUiScreens
{
    public class SandboxBattleEndStatsUiScreen : UiScreen, IGameStateChangeEventSource
    {
        [SerializeField] private Button _returnToEditorButton;

        public event Action<GameStateChangeEvent> OnGameStateChangeEvent;

        private void Awake ()
        {
            _returnToEditorButton.onClick.AddListener(OnReturnToEditorButtonClicked);
        }

        private void OnReturnToEditorButtonClicked()
        {
            OnGameStateChangeEvent?.Invoke(GameStateChangeEvent.CloseBattleEndScreen);
        }
    }
}
