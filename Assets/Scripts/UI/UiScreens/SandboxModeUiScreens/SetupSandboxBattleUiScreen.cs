using System;
using Assets.Scripts.Battles;
using Assets.Scripts.UI.Uis;
using Assets.Scripts.UI.UiScreens.MainMenuUiScreens;
using Assets.Scripts.UI.Validations;
using Assets.Scripts.UI.ViewModels.SpaceShipSetupEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.UiScreens.SandboxModeUiScreens
{
    public class SetupSandboxBattleUiScreen : UiScreen, IGameStateChangeEventSource
    {
        public event Action<GameStateChangeEvent> OnGameStateChangeEvent;

        [SerializeField] private BattleTeamSetupEditor _allyBattleTeamSetupEditor;
        [SerializeField] private BattleTeamSetupEditor _enemyBattleTeamSetupEditor;

        [SerializeField] private Button _enterSandboxBattleButton;
        [SerializeField] private Button _backButton;

        private BattleSetup _battleSetup;

        public override void Setup(Ui ui)
        {
            base.Setup(ui);

            _enterSandboxBattleButton.onClick.AddListener(OnEnterSandboxBattleButtonClicked);
           // _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        public void SetBattleSetupForEditing(BattleSetup battleSetup)
        {
            _battleSetup = battleSetup;

            _allyBattleTeamSetupEditor.SetBattleTeamSetup(_battleSetup.PlayerTeamSetup);
            _enemyBattleTeamSetupEditor.SetBattleTeamSetup(_battleSetup.EnemyTeamSetup);
        }

        private void OnEnterSandboxBattleButtonClicked()
        {
            if(!SandboxBattleEditorValidator.IsBattleSetupValidForBattle(_battleSetup, out string message))
            {
                Debug.Log(message);
                return;
            }

            OnGameStateChangeEvent?.Invoke(GameStateChangeEvent.StartSandboxBattle);
            _ui.GoToScreen<SandboxBattleViewUiScreen>();
        }

        private void OnBackButtonClicked()
        {
            _ui.GoToScreen<MainMenuButtonsUiScreen>();
        }
    }
}
