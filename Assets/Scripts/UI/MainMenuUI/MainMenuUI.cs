using System;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _startBattleButton;
        [SerializeField] private SpaceShipSetupPresenter _playerShipSetup;
        [SerializeField] private SpaceShipSetupPresenter _enemyShipSetup;

        public SpaceShipSetup PlayerSetup
        {
            get => new SpaceShipSetup(_playerShipSetup.SpaceShipType, _playerShipSetup.WeaponTypes);
        }

        public SpaceShipSetup EnemySetup
        {
            get => new SpaceShipSetup(_enemyShipSetup.SpaceShipType, _enemyShipSetup.WeaponTypes);
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
