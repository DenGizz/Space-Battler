using System;
using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MainMenuUI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _startBattleButton;
        [SerializeField] private SpaceShipSetupPresenter _playerShipSetup;
        [SerializeField] private SpaceShipSetupPresenter _enemyShipSetup;

        private SpaceShipSetup PlayerSetup
        {
            get => new SpaceShipSetup(_playerShipSetup.SpaceShipType, _playerShipSetup.WeaponTypes);
            set
            {
                if(value == null)
                {
                    _playerShipSetup.SpaceShipType = SpaceShipType.None;
                    _playerShipSetup.WeaponTypes = null;
                    return;
                }

                _playerShipSetup.SpaceShipType = value.SpaceShipType;
                _playerShipSetup.WeaponTypes = value.WeaponTypes;
            }
        }

        private SpaceShipSetup EnemySetup
        {
            get => new SpaceShipSetup(_enemyShipSetup.SpaceShipType, _enemyShipSetup.WeaponTypes);
            set
            {
                if (value == null)
                {
                    _enemyShipSetup.SpaceShipType = SpaceShipType.None;
                    _enemyShipSetup.WeaponTypes = null;
                    return;
                }
                _enemyShipSetup.SpaceShipType = value.SpaceShipType;
                _enemyShipSetup.WeaponTypes = value.WeaponTypes;
             }
        }


        public event Action OnStartBattleButtonClicked;

        public BattleSetup CreateSetupFromUi()
        {
            return new BattleSetup(PlayerSetup, EnemySetup);
        }

        public void LoadBattleSetupInUi(BattleSetup battleSetup)
        {
            PlayerSetup = battleSetup.PlayerSetup;
            EnemySetup = battleSetup.EnemySetup;
        }


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
