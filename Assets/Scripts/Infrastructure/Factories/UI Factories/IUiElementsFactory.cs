using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.BattleUI;
using Assets.Scripts.UI.MainMenuUI;
using Assets.Scripts.UI.NewUi;
using Assets.Scripts.UI.NewUi.UiElements;
using Assets.Scripts.UI.Pause_Menu_UI;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public interface IUiElementsFactory
    {
        (BattleUI battleUIm, GameObject gameObject) CreateBattleUi();
        MainMenuUI CreateMainMenuUi();
        PauseResumeUI CreatePauseResumeUi();

        DescriptionRowView CreateWeaponDescriptionRow();
        DescriptionRowView CreateSpaceShipDescriptionRow();

        WeaponSelectionPanelViewModel CreateWeaponSelectionPanel();
        SpaceShipSelectionPanelViewModel CreateSpaceShipSelectionPanel();
        BattleWinnerUI CreateWinnerUi();

        HealthView CreateHealthView(ISpaceShip spaceShip, Vector2 screenPosition, Transform parent);

        WindowPanel CreateWeaponSelectionWindowPanel(out SelectionGrid selectionGrid);
        WeaponTypeSlotViewModel CreateWeaponTypeSlot(Transform weaponSlotViewModelsContainer);
    }
}