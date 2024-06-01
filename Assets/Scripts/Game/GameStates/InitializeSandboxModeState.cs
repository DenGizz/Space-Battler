using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.Infrastructure.Ui.Providers;

namespace Assets.Scripts.Game.GameStates.SandboxLoopStates
{
    public class InitializeSandboxModeState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IUiFactory _uiFactory;
        private readonly IUisProvider _uisProvider;

        public InitializeSandboxModeState(IStateMachine stateMachine, IUiFactory uiFactory, IUisProvider uisProvider)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _uisProvider = uisProvider;
        }

        public void Enter()
        {
            var _sandboxUi = _uiFactory.CreateSandboxBattleUi();
            _uisProvider.SandboxModeUi = _sandboxUi;
            _stateMachine.EnterState<SandboxModeLoopState>();
        }

        public void Exit(){}
    }
}
