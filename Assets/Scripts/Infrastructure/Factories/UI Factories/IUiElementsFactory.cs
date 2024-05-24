using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.BattleUI;
using Assets.Scripts.UI.NewUi;
using Assets.Scripts.UI.NewUi.UiElements;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public interface IUiElementsFactory
    {
        HealthView CreateHealthView(ISpaceShip spaceShip, Vector2 screenPosition, Transform parent);
        WeaponTypeSlotViewModel CreateWeaponTypeSlot(Transform weaponSlotViewModelsContainer);

        UiGrid CreateUiGrid();
    }
}