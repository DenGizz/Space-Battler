using System.Collections;
using Assets.Scripts.UI;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.WeaponSelectionUI;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public interface IUIFactory
    {
        (BattleUI battleUIm, GameObject gameObject) CreateBattleUI();
        MainMenuUI CreateMainMenuUI();
        PauseResumeUI CreatePauseResumeUi();

        DescriptionRowView CreateWeaponDescriptionRowView();
        DescriptionRowView CreateSpaceShipDescriptionRowView();

        WeaponSelectionPanelViewModel CreateWeaponSelectionPanelViewPanel();
        SpaceShipSelectionPanelViewModel CreateSpaceShipSelectionPanel();
    }
}