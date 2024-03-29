using Assets.Scripts.AI;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Units;
using Assets.Scripts.Units.UnitComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTestScript : MonoBehaviour
{
    [SerializeField] private TestCombatUnitComponent playerCombatUnitComponent;
    [SerializeField] private TestCombatUnitComponent enemyCombatUnitComponent;

    [SerializeField] private AutoAttackAI playerAutoAttackAI;
    [SerializeField] private AutoAttackAI enemyAutoAttackAI;

    private ICombatUnit playerCombatUnit;
    private ICombatUnit enemyCombatUnit;

    private ICombatAI playerAI;
    private ICombatAI enemyAI;

    private void InitializeBattle()
    {
        playerCombatUnit = playerCombatUnitComponent;
        enemyCombatUnit = enemyCombatUnitComponent;

        playerAI = playerAutoAttackAI;
        enemyAI = enemyAutoAttackAI;

        playerAI.SetTarget(enemyCombatUnit);
        enemyAI.SetTarget(playerCombatUnit);
    }

    private void StartBattle()
    {
        playerAI.StartCombat();
        enemyAI.StartCombat();
    }

    private void StopBattle()
    {
        playerAI.StopCombat();
        enemyAI.StopCombat();
    }

    private void ObserveBattle()
    {
        if(playerCombatUnit.HealthAttribute.HP <= 0)
        {
            Destroy(playerCombatUnitComponent.gameObject);
            StopBattle();
        }

        if(enemyCombatUnit.HealthAttribute.HP <= 0)
        {
            Destroy(enemyCombatUnitComponent.gameObject);
            StopBattle();
        }
    }
}
