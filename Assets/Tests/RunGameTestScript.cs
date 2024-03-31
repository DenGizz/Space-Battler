using Assets.Scripts.AI;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Units;
using Assets.Scripts.Units.UnitAttributes;
using Assets.Scripts.Units.UnitComponents;
using UnityEngine;
using Zenject;

public class RunGameTestScript : MonoBehaviour
{
    IBattleRunnerService _battleRunnerService;

    [Inject]
    public void Construct(IBattleRunnerService battleRunnerService)
    {
        _battleRunnerService = battleRunnerService;
    }

    [ContextMenu("Setup Battle")]
    public void SetupBattle()
    {
        _battleRunnerService.SetupBattle();
    }

    [ContextMenu("Start Battle")]
    public void StartBattle()
    {
        _battleRunnerService.StartBattle();
    }

    [ContextMenu("Stop Battle")]
    public void StopBattle()
    {
        _battleRunnerService.StopBattle();
    }

    [ContextMenu("CleanUp Battle")]
    public void CleanUpBattle()
    {
        _battleRunnerService.CleanUpBattle();
    }


    private string GetBattleStatInfoString(ISpaceShip player, ISpaceShip enemy)
    {
        string GetWeaponInfo(IWeapon weapon)
        {
            return $"Weapon. Damage: {weapon.Damage} ColdDown time: {weapon.ColdDownTime})";
        }

        string GetUnitInfo(ISpaceShip unit)
        {
            string baseUnitInfo =
                $"Unit: {unit.GetType().Name}, Health: {GetAttributeInfo(unit.HealthAttribute)}";

            string weaponsInfo = "";
            if (unit is ISpaceShip combatEntity)
                foreach (var weapon in combatEntity.Weapons)
                    weaponsInfo += $"{GetWeaponInfo(weapon)}\n";

            return baseUnitInfo + "\n" + weaponsInfo;
        }

        string GetAttributeInfo(IHealthAttribute attribute) =>
            $"[{attribute.HP}/{attribute.BaseHP}]";

        return $"Player:\n{GetUnitInfo(player)}\n\nEnemy:\n{GetUnitInfo(enemy)}";
    }
}
