﻿using Assets.Scripts.Entities.Weapons.WeaponConfigs;
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
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Zenject;
using Assets.Scripts.UI.ViewModels.SlotViewModels;
using Assets.Scripts.UI.ViewModels.SpaceShipViewModels;

namespace Assets.Scripts.UI.NewUi
{
    [RequireComponent(typeof(WeaponTypeViewModel))]
    public class WeaponTypeSlotViewModel : ItemSlotViewModel<WeaponType, WeaponTypeViewModel>
    {
        protected override WeaponType SetSelectedItem(MonoBehaviour selectedView)
        {
            if (selectedView is IWeaponTypeViewModel weaponViewModel)
                return weaponViewModel.WeaponType;

            throw new ArgumentException("Selected view is not weapon view model");
        }

        protected override void UpdateView()
        {
            _view.WeaponType = SelectedItem;
        }
    }
}
