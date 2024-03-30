using Assets.Scripts.AI;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Units;
using Assets.Scripts.Units.UnitComponents;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Units.UnitAttributes;
using UnityEngine;

public class BattleTestScript : MonoBehaviour
{
    [SerializeField] private BattleInfoUIViewModel _battleInfoUi;

    [SerializeField] private TestCombatUnitComponent playerCombatUnitComponent;
    [SerializeField] private TestCombatUnitComponent enemyCombatUnitComponent;

    [SerializeField] private AutoAttackAI playerAutoAttackAI;
    [SerializeField] private AutoAttackAI enemyAutoAttackAI;

    private ICombatUnit playerCombatUnit;
    private ICombatUnit enemyCombatUnit;

    private ICombatAI playerAI;
    private ICombatAI enemyAI;

    private bool _isBattleStopped;

    private void Start()
    {
        InitializeBattle();
        StartBattle();
    }

    private void LateUpdate()
    {
        ObserveBattle();
        _battleInfoUi.WriteInfo(GetBattleStatInfoString(playerCombatUnit, enemyCombatUnit));
    }

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

        _isBattleStopped = false;
    }

    private void StopBattle()
    {
        playerAI.StopCombat();
        enemyAI.StopCombat();

        _isBattleStopped = true;
    }

    private void ObserveBattle()
    {
        if (_isBattleStopped)
            return;

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

    private string GetBattleStatInfoString(ICombatUnit player, ICombatUnit enemy)
    {
        string GetWeaponInfo(IWeapon weapon)
        {
            return $"Weapon. Damage: {weapon.Damage} ColdDown time: {weapon.ColdDownTime})";
        }

        string GetUnitInfo(ICombatUnit unit)
        {
            string baseUnitInfo =
                $"Unit: {unit.GetType().Name}, Health: {GetAttributeInfo(unit.HealthAttribute)}";

            string weaponsInfo = "";
            if (unit is ICombatUnit combatEntity)
                foreach (var weapon in combatEntity.Weapons)
                    weaponsInfo += $"{GetWeaponInfo(weapon)}\n";

            return baseUnitInfo + "\n" + weaponsInfo;
        }

        string GetAttributeInfo(IHealthAttribute attribute) =>
            $"[{attribute.HP}/{attribute.BaseHP}]";

       return $"Player:\n{GetUnitInfo(player)}\n\nEnemy:\n{GetUnitInfo(enemy)}";
    }
}
