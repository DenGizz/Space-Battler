using Assets.Scripts.Game.GameStates.SandboxLoopStates;
using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.Core.Factories;

namespace Assets.Scripts.Game.GameStates
{
    public class SandboxModeLoopState : IState
    {
        private readonly IStateMachine _gameStateMachine;
        private readonly IStateMachine _sandboxModeLoopStateMachine;

        //TODO: Create factory fot this state machine and create it on enter this state
        //TODO: Maybe remove UIs provider and inject UI when state machine is created
        public SandboxModeLoopState(IStateMachine gameStateMachine, IStatesFactory statesFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sandboxModeLoopStateMachine = new StateMachine();
            _sandboxModeLoopStateMachine.AddState<LoadBattleFieldSceneState>(statesFactory.CreateState<LoadBattleFieldSceneState>(_sandboxModeLoopStateMachine));
            _sandboxModeLoopStateMachine.AddState<InitializeSandboxModeState>(statesFactory.CreateState<InitializeSandboxModeState>(_sandboxModeLoopStateMachine));
            _sandboxModeLoopStateMachine.AddState<EditBattleSetupState>(statesFactory.CreateState<EditBattleSetupState>(_sandboxModeLoopStateMachine));
            _sandboxModeLoopStateMachine.AddState<CreateBattleState>(statesFactory.CreateState<CreateBattleState>(_sandboxModeLoopStateMachine));
            _sandboxModeLoopStateMachine.AddState<BattleState>(statesFactory.CreateState<BattleState>(_sandboxModeLoopStateMachine));
            _sandboxModeLoopStateMachine.AddState<CleanUpBattleState>(statesFactory.CreateState<CleanUpBattleState>(_sandboxModeLoopStateMachine));
            _sandboxModeLoopStateMachine.AddState<ShowWinnerState>(statesFactory.CreateState<ShowWinnerState>(_sandboxModeLoopStateMachine));
            _sandboxModeLoopStateMachine.AddState<ExitSandboxModeState>(statesFactory.CreateSubState<ExitSandboxModeState>(_sandboxModeLoopStateMachine, _gameStateMachine));

        }

        public void Enter()
        {
            _sandboxModeLoopStateMachine.EnterState<LoadBattleFieldSceneState>();
        }

        public void Exit()
        {
        }
    }
}
