using System.Collections.Generic;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.UI.UiElements;
using Assets.Scripts.UI.ViewModels;
using Assets.Scripts.UI.ViewModels.SlotViewModels;
using Assets.Scripts.UI.ViewModels.SpaceShipViewModels;
using Assets.Scripts.UI.ViewModels.WeaponViewModels;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Ui.Factories
{
    public interface IUiElementsFactory
    {
        HealthView CreateHealthView(ISpaceShip spaceShip, Vector2 screenPosition, Transform parent);
        WeaponTypeSlotViewModel CreateWeaponTypeSlot(Transform weaponSlotViewModelsContainer, IEnumerable<WeaponType> options);

        UiGrid CreateUiGrid();
        WeaponTypeRowViewModel CreateWeaponTypeRowView();
        SpaceShipTypeRowViewModel CreateSpaceShipTypeRowView();
    }
}