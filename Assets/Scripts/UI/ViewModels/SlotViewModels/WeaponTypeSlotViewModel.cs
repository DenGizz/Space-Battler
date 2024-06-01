using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.SelectionPanels;
using Assets.Scripts.UI.WeaponViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using UnityEngine;
using Assets.Scripts.UI.NewUi.WeaponViewModels;
using Assets.Scripts.UI.NewUi.UiElements;
using Zenject;
using Assets.Scripts.UI.ViewModels.SlotViewModels;
using Assets.Scripts.UI.ViewModels.SpaceShipViewModels;

namespace Assets.Scripts.UI.NewUi
{
    public class WeaponTypeSlotViewModel : ItemSlotViewModel<WeaponType>
    {
        private IWeaponTypeViewModel _weaponTypeViewModel;

        override public WeaponType SelectedOption
        {
            get => base.SelectedOption;
            set
            {
                base.SelectedOption = value;
                _weaponTypeViewModel.WeaponType = value;
            }
        }

        private void Awake()
        {
            _weaponTypeViewModel = GetComponentInParent<IWeaponTypeViewModel>() ?? throw new NullReferenceException("WeaponTypeViewModel not found");
        }
    }
}
