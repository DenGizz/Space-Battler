using System;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.SpaceShipSetupPanel;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _startBattleButton;
        [SerializeField] private SpaceShipSetupPanelViewModel _playerShipSetup;
        [SerializeField] private SpaceShipSetupPanelViewModel _enemyShipSetup;

        public SpaceShipSetup PlayerSetup
        {
            get => new SpaceShipSetup(_playerShipSetup.SelectedSpaceShipType, _playerShipSetup.SelectedWeaponTypes);
        }

        public SpaceShipSetup EnemySetup
        {
            get => new SpaceShipSetup(_enemyShipSetup.SelectedSpaceShipType, _enemyShipSetup.SelectedWeaponTypes);
        }


        public event Action OnStartBattleButtonClicked;

        private void Awake()
        {
            _startBattleButton.onClick.AddListener(OnStartBattleButtonClick);
        }

        private void OnStartBattleButtonClick()
        {
            OnStartBattleButtonClicked?.Invoke();
        }
    }
}
