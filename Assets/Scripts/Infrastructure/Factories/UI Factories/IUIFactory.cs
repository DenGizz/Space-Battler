using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public interface IUIFactory
    {
        (BattleUI battleUIm, GameObject gameObject) CreateBattleUI();
    }
}