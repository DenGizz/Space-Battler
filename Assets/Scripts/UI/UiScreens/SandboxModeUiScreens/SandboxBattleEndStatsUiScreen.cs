using System;
using Assets.Scripts.Battles;
using Assets.Scripts.UI.Uis;
using Assets.Scripts.UI.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.UiScreens.SandboxModeUiScreens
{
    public class SandboxBattleEndStatsUiScreen : UiScreen, IGameStateChangeEventSource
    {
        [SerializeField] private Button _returnToEditorButton;
        [SerializeField] private BattleWinnerViewModel _battleWinnerViewModel;

        public event Action<GameStateChangeEvent> OnGameStateChangeEvent;

        private void Awake ()
        {
            _returnToEditorButton.onClick.AddListener(OnReturnToEditorButtonClicked);
        }

        public void SetBattleResult(BattleResult battleResult)
        {
            _battleWinnerViewModel.SetWinner(battleResult);
        }

        private void OnReturnToEditorButtonClicked()
        {
            OnGameStateChangeEvent?.Invoke(GameStateChangeEvent.CloseBattleEndScreen);
        }
    }
}
