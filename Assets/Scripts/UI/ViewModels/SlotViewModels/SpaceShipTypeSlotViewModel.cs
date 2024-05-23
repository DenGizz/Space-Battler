using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
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
    [RequireComponent(typeof(SpaceShipTypeViewModel))]
    public class SpaceShipTypeSlotViewModel : ItemSlotViewModel<SpaceShipType, SpaceShipTypeViewModel>
    {
        protected override SpaceShipType SetSelectedItem(MonoBehaviour selectedView)
        {
            if (selectedView is ISpaceShipViewModel spaceShipViewModel)
                return spaceShipViewModel.SpaceShipType;

            throw new ArgumentException("Selected view is not a space ship view model");
        }

        protected override void UpdateView()
        {
            _view.SpaceShipType = SelectedItem;
        }
    }
}
