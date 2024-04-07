using System.Collections;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public interface IUIFactory
    {
        (BattleUI battleUIm, GameObject gameObject) CreateBattleUI();
        MainMenuUI CreateMainMenuUI();
        DescriptionRowView CreateWeaponDescriptionRowView();
        WeaponSelectionPanelViewModel WeaponSelectionPanelViewPanel();
    }
}