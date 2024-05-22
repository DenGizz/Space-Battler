using Assets.Scripts.UI.NewUi.SpaceShipSetupEditPanel;
using Assets.Scripts.UI.NewUi.Uis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.NewUi.UiScreens.MainMenuUiScreens
{
    public class SetupSandboxBattleUiScreen : UiScreen, IGameStateChangeEventSource
    {
        public event Action<GameStateChangeEvent> OnGameStateChangeEvent;

        [SerializeField] private SpaceShipSetupEditViewModel _playerSpaceShipEditor;
        [SerializeField] private SpaceShipSetupEditViewModel _enemySpaceShipEditor;

        [SerializeField] private Button _enterSandboxBattleButton;
        [SerializeField] private Button _backButton;

        override public void Setup(Ui ui)
        {
            base.Setup(ui);

            _enterSandboxBattleButton.onClick.AddListener(OnEnterSandboxBattleButtonClicked);
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnEnterSandboxBattleButtonClicked()
        {
            OnGameStateChangeEvent?.Invoke(GameStateChangeEvent.EnterSandboxMode);
        }

        private void OnBackButtonClicked()
        {
            _ui.GoToScreen<MainMenuButtonsUiScreen>();
        }
    }
}
