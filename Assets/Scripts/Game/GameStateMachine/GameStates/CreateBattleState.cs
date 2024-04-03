using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.SpaceShip;
using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Game.GameStateMachine.GameStates
{
    public class CreateBattleState : IState
    {
        private readonly ISpaceShipFactory _spaceShipFactory;
        private readonly IBattleUIService _battleUIService;
        private readonly IBattleFactory _battleFactory;

        private readonly GameStateMachine GameStateMachine;

        public CreateBattleState(GameStateMachine gameStateMachine, ISpaceShipFactory spaceShipFactory , IBattleUIService battleUIService, IBattleFactory battleFactory)
        {
            GameStateMachine = gameStateMachine;
            _spaceShipFactory = spaceShipFactory;
            _battleUIService = battleUIService;
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

            Battle.Battle battle = _battleFactory.CreateBattle(player, enemy);


            _battleUIService.CreateBattleUI();
            _battleUIService.SetBattle(battle);
        }
    }
}
