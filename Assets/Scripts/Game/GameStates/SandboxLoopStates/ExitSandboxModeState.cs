using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.GameStates.SandboxLoopStates
{
    public class ExitSandboxModeState : SubState
    {
        public ExitSandboxModeState(IStateMachine substateMachine, IStateMachine parentStateMachine) : base(parentStateMachine, substateMachine)
        {
        }

        public override void Enter()
        {
            _parentStateMachine.EnterState<LoadMainMenuSceneState>();
        }

        public override void Exit()
        {

        }
    }
}
