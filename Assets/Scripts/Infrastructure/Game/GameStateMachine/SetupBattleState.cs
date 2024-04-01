using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShip;
using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine
{
    public class SetupBattleState : IState
    {
        private readonly ISpaceShipFactory _spaceShipFactory;
        private readonly ICombatAIRegistry _combatAIRegistry;
        private readonly IBattleUIService _battleUIService;
        private readonly IBattleDataProvider _battleDataProvider;

        private readonly GameStateMachine GameStateMachine;



        public SetupBattleState(GameStateMachine gameStateMachine, ISpaceShipFactory spaceShipFactory, ICombatAIRegistry combatAIRegistry, IBattleUIService battleUIService, IBattleDataProvider battleDataProvider)
        {
            GameStateMachine = gameStateMachine;
            _spaceShipFactory = spaceShipFactory;
            _combatAIRegistry = combatAIRegistry;
            _battleUIService = battleUIService;
            _battleDataProvider = battleDataProvider;
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
            _battleDataProvider.CurrentBattleData = battle;
        }
    }
}
