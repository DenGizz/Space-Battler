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
    public class CreateBattleState : IState
    {
        private readonly ISpaceShipFactory _spaceShipFactory;
        private readonly ICombatAIRegistry _combatAIRegistry;
        private readonly IBattleUIService _battleUIService;
        private readonly IBattleDataProvider _battleDataProvider;
        private readonly IBattleFactory _battleFactory;

        private readonly GameStateMachine GameStateMachine;

        public CreateBattleState(GameStateMachine gameStateMachine, ISpaceShipFactory spaceShipFactory, ICombatAIRegistry combatAIRegistry, IBattleUIService battleUIService, IBattleDataProvider battleDataProvider, IBattleFactory battleFactory)
        {
            GameStateMachine = gameStateMachine;
            _spaceShipFactory = spaceShipFactory;
            _combatAIRegistry = combatAIRegistry;
            _battleUIService = battleUIService;
            _battleDataProvider = battleDataProvider;
            _battleFactory = battleFactory;
        }

        public void Enter()
        {
            CreateBattle();
            GameStateMachine.EnterState<BattleState>();
        }

        public void Exit()
        {

        }

        private void CreateBattle()
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

            BattleData battle = _battleFactory.CreateBattleForSpaceShips(player, enemy);
            _battleDataProvider.CurrentBattleData = battle;

            _battleUIService.CreateBattleUI();
            _battleUIService.SetBattle(battle);

        }
    }
}
