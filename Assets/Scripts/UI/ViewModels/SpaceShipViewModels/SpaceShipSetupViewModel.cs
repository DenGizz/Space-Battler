using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.UI.ViewModels.WeaponViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.ViewModels.SpaceShipViewModels
{
    public class SpaceShipSetupViewModel : MonoBehaviour
    {
        private SpaceShipSetup _spaceShipSetup;

        public SpaceShipSetup SpaceShipSetup
        {
            get => _spaceShipSetup;
            set
            {
                _spaceShipSetup = value;
                UpdateView();
            }
        }

        private SpaceShipTypeViewModel _spaceShipTypeViewModel;

        private WeaponTypeViewModel[] _weaponTypeViewModels;

        private void Awake()
        {
            _spaceShipTypeViewModel = GetComponentInChildren<SpaceShipTypeViewModel>();
            _weaponTypeViewModels = GetComponentsInChildren<WeaponTypeViewModel>();
        }

        private void UpdateView()
        {
            _spaceShipTypeViewModel.SpaceShipType = _spaceShipSetup.SpaceShipType;

            for (int i = 0; i < _weaponTypeViewModels.Length; i++)
            {
                if (i < _spaceShipSetup.WeaponTypes.Count)
                {
                    _weaponTypeViewModels[i].WeaponType = _spaceShipSetup.WeaponTypes[i];
                }
                else
                {
                    _weaponTypeViewModels[i].WeaponType = WeaponType.None;
                }
            }
        }
    }
}
