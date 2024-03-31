using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Units;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Infrastructure.Services.Factories;
using Assets.Scripts.Infrastructure.Services;

public class SetupBattleState : IState
{
    private readonly ISpaceShipFactory _spaceShipFactory;
    private readonly ICombatAIRegistry _combatAIRegistry;
    private readonly IBattleUIService _battleUIService;
    private readonly GameStateMachine GameStateMachine;



    public SetupBattleState(GameStateMachine gameStateMachine, ISpaceShipFactory spaceShipFactory, ICombatAIRegistry combatAIRegistry, IBattleUIService battleUIService)
    {
        GameStateMachine = gameStateMachine;
        _spaceShipFactory = spaceShipFactory;
        _combatAIRegistry = combatAIRegistry;
        _battleUIService = battleUIService;
    }

    public void Enter()
    {
        SetupBattle();
        GameStateMachine.EnterState<BattleRunningState>();
    }

    public void Exit()
    {

    }

    private void SetupBattle()
    {
        //Instantiate units
        ISpaceShip player = _spaceShipFactory.CreatePlayerSpaceShip(Vector3.zero - Vector3.right * 7);
        ISpaceShip enemy = _spaceShipFactory.CreateEnemySpaceShip(Vector3.zero + Vector3.right * 7);
        //Find target for each combat unit
        ICombatAI playerAI = _combatAIRegistry.GetAI(player);
        ICombatAI enemyAI = _combatAIRegistry.GetAI(enemy);
        //Setup targets in unit ai
        playerAI.SetTarget(enemy);
        enemyAI.SetTarget(player);

        BattleData battle = new BattleData(player, enemy, playerAI, enemyAI, false, false);

        _battleUIService.CreateBattleUI();
        _battleUIService.SetBattle(battle);

        GameStateMachine.BattleData = battle;
    }
}
