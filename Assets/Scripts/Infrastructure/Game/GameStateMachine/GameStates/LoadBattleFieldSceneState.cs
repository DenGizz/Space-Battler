using System.Collections;
using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine.GameStates
{
    public class LoadBattleFieldSceneState : IState
    {
        private readonly GameStateMachine GameStateMachine;

        public LoadBattleFieldSceneState(GameStateMachine gameStateMachine)
        {
            GameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            LoadBattleFieldScene();
            GameStateMachine.EnterState<CreateBattleState>();
        }

        public void Exit()
        {

        }

        private void LoadBattleFieldScene()
        {

        }
    }
}