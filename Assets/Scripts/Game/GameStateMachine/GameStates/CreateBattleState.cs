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
            Vector3 playerSpaceShipPosition = Vector3.zero - Vector3.right * 7;
            Vector3 enemySpaceShipPosition = Vector3.zero + Vector3.right * 7;

            float playerSpaceShipZRotation = -90;
            float enemySpaceShipZRotation = 90;

            Color playerSpaceShipColor = Color.green;
            Color enemySpaceShipColor = Color.red;

            SpaceShipConfig playerSpaceShipConfig = new SpaceShipConfig(25, 1);
            SpaceShipConfig enemySpaceShipConfig = new SpaceShipConfig(25, 1);

            ISpaceShip player = _spaceShipFactory.CreateSpaceShip(playerSpaceShipConfig, playerSpaceShipPosition, playerSpaceShipZRotation, playerSpaceShipColor);
            ISpaceShip enemy = _spaceShipFactory.CreateSpaceShip(enemySpaceShipConfig, enemySpaceShipPosition, enemySpaceShipZRotation, enemySpaceShipColor);

            Battle.Battle battle = _battleFactory.CreateBattle(player, enemy);

            _battleUIService.CreateBattleUI();
            _battleUIService.SetBattle(battle);
        }
    }
}
