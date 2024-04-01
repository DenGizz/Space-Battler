using Assets.Scripts.AI;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.Factories;
using Assets.Scripts.Units;
using Assets.Scripts.Units.UnitAttributes;
using Assets.Scripts.Units.UnitComponents;
using UnityEngine;
using Zenject;

public class RunGameTestScript : MonoBehaviour
{
    private ISpaceShipFactory _spaceShipFactory;
    private ICombatAIRegistry _combatAIRegistry;
    private IBattleUIService _battleUIService;
    private IBattleObserver _battleObserver;
    private ISpaceShipsGameObjectRegistry _spaceShipsGameObjectRegistry;
     private ISpaceShipRegistry _spaceShipRegistry;

    [Inject]
    public void Construct( ISpaceShipFactory spaceShipFactory, ICombatAIRegistry combatAIRegistry, IBattleUIService battleUIService, IBattleObserver battleObserver, ISpaceShipsGameObjectRegistry spaceShipsGameObjectRegistry, ISpaceShipRegistry spaceShipRegistry)
    {
        _spaceShipFactory = spaceShipFactory;
        _combatAIRegistry = combatAIRegistry;
        _battleUIService = battleUIService;
        _battleObserver = battleObserver;
        _spaceShipsGameObjectRegistry = spaceShipsGameObjectRegistry;
        _spaceShipRegistry = spaceShipRegistry;
    }


    [ContextMenu("Run Game StateMachine")]
    public void RunGameStateMachine()
    {
        GameStateMachine stateMachine = new GameStateMachine(_spaceShipFactory, _combatAIRegistry, _battleUIService, _battleObserver, _spaceShipsGameObjectRegistry,  _spaceShipRegistry);
        stateMachine.EnterState<SetupBattleState>();
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
