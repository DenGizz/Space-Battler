using Assets.Scripts.AI;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Units;
using Assets.Scripts.Units.UnitAttributes;
using Assets.Scripts.Units.UnitComponents;
using UnityEngine;

public class BattleTestScript : MonoBehaviour
{
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
