using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.BattleUI;
using Assets.Scripts.UI.MainMenuUI;
using Assets.Scripts.UI.Pause_Menu_UI;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public interface IUiFactory
    {
        (BattleUI battleUIm, GameObject gameObject) CreateBattleUi();
        MainMenuUI CreateMainMenuUi();
        PauseResumeUI CreatePauseResumeUi();

        DescriptionRowView CreateWeaponDescriptionRow();
        DescriptionRowView CreateSpaceShipDescriptionRow();

        WeaponSelectionPanelViewModel CreateWeaponSelectionPanel();
        SpaceShipSelectionPanelViewModel CreateSpaceShipSelectionPanel();
        BattleWinnerUI CreateWinnerUi();
    }
}