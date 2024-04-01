using Assets.Scripts;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.Factories;
using Assets.Scripts.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : StateMachine
{
    //TODO: Create BattleData provider service ???
    public BattleData BattleData { get; set; }

    //TODO: Register GameStateMachine as service. Create state factory to auto resolve dependencies
    //TODO: Bind states in States installer
    public GameStateMachine(ISpaceShipFactory spaceShipFactory, ICombatAIRegistry combatAIRegistry, IBattleUIService battleUIService, IBattleObserver battleObserver, ISpaceShipsGameObjectRegistry spaceShipsGameObjectRegistry, ISpaceShipRegistry spaceShipRegistry)
    {
        States[typeof(SetupBattleState)] = new SetupBattleState(this, spaceShipFactory, combatAIRegistry, battleUIService);
        States[typeof(BattleRunningState)] = new BattleRunningState(this, battleObserver, combatAIRegistry);
        States[typeof(CleanUpBattleState)] = new CleanUpBattleState(this, spaceShipsGameObjectRegistry, spaceShipRegistry, combatAIRegistry, battleUIService);
    }
}
