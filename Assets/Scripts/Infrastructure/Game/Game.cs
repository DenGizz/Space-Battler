using Assets.Scripts.Infrastructure.Game.GameStateMachine;
using System.Collections;
using Assets.Scripts.Infrastructure.Game.GameStateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Game
{
    public class Game
    {
        private readonly GameStateMachine.GameStateMachine _gameStateMachine;

        [Inject]
        public Game(GameStateMachine.GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Start()
        {
            _gameStateMachine.EnterState<LoadBattleFieldSceneState>();
        }
    }
}