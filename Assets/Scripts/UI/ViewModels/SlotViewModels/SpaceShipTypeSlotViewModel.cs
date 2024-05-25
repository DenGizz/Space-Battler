using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.NewUi.ItemSelectionViewModels;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using Assets.Scripts.UI.ViewModels.SlotViewModels;
using Assets.Scripts.UI.ViewModels.SpaceShipViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.NewUi.SlotViewModels
{
    public class SpaceShipTypeSlotViewModel : ItemSlotViewModel<SpaceShipType>
    {
        private ISpaceShipViewModel _spaceShipViewModel;

        override public SpaceShipType SelectedOption
        {
            get => base.SelectedOption;
            set
            {
                base.SelectedOption = value;
                _spaceShipViewModel.SpaceShipType=value;
            }
        }

        private void Awake()
        {
            _spaceShipViewModel = GetComponentInParent<ISpaceShipViewModel>() ?? throw new NullReferenceException("SpaceShipViewModel not found");
        }
    }
}
