using Assets.Scripts.AI;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Game;
using Assets.Scripts.Infrastructure.Game.GameStateMachine;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShip;
using Assets.Scripts.SpaceShip.SpaceShipAttributes;
using UnityEngine;
using Zenject;

public class RunGameTestScript : MonoBehaviour
{
    private Game _game;

    [Inject]
    public void Construct(Game game)
    {
        _game = game;
    }


    [ContextMenu("StartGame")]
    public void RunGameStateMachine()
    {
        _game.Start();  
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
