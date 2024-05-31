using Assets.Scripts.Battles;
using Assets.Scripts.UI.BattleUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandboxBattleViewUiScreen : UiScreen
{
    [SerializeField] private BattleView _battleView;

    public void SetBattleData(BattleData battleData)
    {
        _battleView.Clear();
        _battleView.SetBattleData(battleData);
    }
}
