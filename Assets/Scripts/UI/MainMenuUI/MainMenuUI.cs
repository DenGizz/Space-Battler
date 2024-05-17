using System;
using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MainMenuUI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject _sandboxBattleSetupUi;
        [SerializeField] private Button _playSandboxModeButton;
        [SerializeField] private GameObject _mainMenuButtons;
        [SerializeField] private Button _playSandBoxModeButton;
        [SerializeField] private SpaceShipSetupPresenter _playerShipSetup;
        [SerializeField] private SpaceShipSetupPresenter _enemyShipSetup;

        public BattleSetup _battleSetup;

        public event Action OnStartBattleButtonClicked;

        public void SetBattleSetup(BattleSetup battleSetup)
        {
            _playerShipSetup.SetSpaceShipSetup(battleSetup.PlayerSetup);
            _enemyShipSetup.SetSpaceShipSetup(battleSetup.EnemySetup);
        }

        private void Awake()
        {
            _playSandBoxModeButton.onClick.AddListener(OnStartBattleButtonClick);
            _playSandboxModeButton.onClick.AddListener(OnPlaySandboxModeButtonClick);
        }

        private void OnStartBattleButtonClick()
        {      
            OnStartBattleButtonClicked?.Invoke();
        }

        private void OnPlaySandboxModeButtonClick()
        {
            _mainMenuButtons.SetActive(false);
            _sandboxBattleSetupUi.SetActive(true);
        }
    }
}
