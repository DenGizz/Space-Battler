using Assets.Scripts.Game.GameStates;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.StateMachines;
using Zenject;

namespace Assets.Scripts.Game
{
    public class Game
    {
        private readonly StateMachine _gameStateMachine;

        [Inject]
        public Game(IStatesFactory statesFactory)
        {
            _gameStateMachine = new StateMachine();
            _gameStateMachine.AddState<LoadMainMenuSceneState>(statesFactory.CreateState<LoadMainMenuSceneState>(_gameStateMachine));
            _gameStateMachine.AddState<MainMenuState>(statesFactory.CreateState<MainMenuState>(_gameStateMachine));
            _gameStateMachine.AddState<LoadBattleFieldSceneState>(statesFactory.CreateState<LoadBattleFieldSceneState>(_gameStateMachine));
            _gameStateMachine.AddState<CreateBattleState>(statesFactory.CreateState<CreateBattleState>(_gameStateMachine));
            _gameStateMachine.AddState<BattleState>(statesFactory.CreateState<BattleState>(_gameStateMachine));
            _gameStateMachine.AddState<CleanUpBattleState>(statesFactory.CreateState<CleanUpBattleState>(_gameStateMachine));
        }

        public void Start()
        {
            _gameStateMachine.EnterState<LoadMainMenuSceneState>();
        }
    }
}