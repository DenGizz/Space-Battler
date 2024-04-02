using Assets.Scripts.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine.GameStates
{
    public class MainMenuState : IState
    {
        private GameStateMachine _gameStateMachine;

        public MainMenuState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }
    }
}
