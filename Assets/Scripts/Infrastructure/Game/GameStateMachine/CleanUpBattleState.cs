using Assets.Scripts;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.Factories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpBattleState : IState
{
    private readonly ISpaceShipsGameObjectRegistry _spaceShipsGameObjectRegistry;
    private readonly ISpaceShipRegistry _spaceShipRegistry;
    private readonly ICombatAIRegistry _combatAIRegistry;
    private readonly IBattleUIService _battleUIService;
    private readonly GameStateMachine _gameStateMachine;

    public CleanUpBattleState(GameStateMachine gameStateMachine, ISpaceShipsGameObjectRegistry spaceShipsGameObjectRegistry, ISpaceShipRegistry spaceShipRegistry, ICombatAIRegistry combatAIRegistry, IBattleUIService battleUIService)
    {
        _gameStateMachine = gameStateMachine;
        _spaceShipsGameObjectRegistry = spaceShipsGameObjectRegistry;
        _spaceShipRegistry = spaceShipRegistry;
        _combatAIRegistry = combatAIRegistry;
        _battleUIService = battleUIService;
      
    }

    public void Enter()
    {
        BattleData battleData = _gameStateMachine.BattleData;

        GameObject.Destroy(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.PlayerSpaceShip));
        GameObject.Destroy(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.EnemySpaceShip));

        _spaceShipsGameObjectRegistry.UnregisterGameObject(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.PlayerSpaceShip));
        _spaceShipsGameObjectRegistry.UnregisterGameObject(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.EnemySpaceShip));

        _spaceShipRegistry.PlayerSpaceShip = null;
        _spaceShipRegistry.EnemySpaceShip = null;

        _combatAIRegistry.UnregisterAI(battleData.PlayerSpaceShip);
        _combatAIRegistry.UnregisterAI(battleData.EnemySpaceShip);
        _battleUIService.DestroyBattleUI();
    }

    public void Exit()
    {

    }
}
