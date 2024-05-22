using Assets.Scripts.UI.NewUi.Uis;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.NewUi.UiScreens
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
