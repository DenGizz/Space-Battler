using Assets.Scripts;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.Factories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpBattleState : IState
{
    ISpaceShipsGameObjectRegistry _spaceShipsGameObjectRegistry;
    ISpaceShipRegistry _spaceShipRegistry;
    ICombatAIRegistry _combatAIRegistry;
    IBattleUIService _battleUIService;
    private readonly GameStateMachine _gameStateMachine;

    public CleanUpBattleState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
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
