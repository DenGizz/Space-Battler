using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.StateMachines;
using Assets.Scripts.UI.NewUi.Uis;
using Assets.Scripts.UI.NewUi.UiScreens.MainMenuUiScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.GameStates.SandboxLoopStates
{
    public class EditBattleSetupState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IUiFactory _uiFactory;

        private Ui _sandboxUi;

        public EditBattleSetupState(StateMachine stateMachine, IUiFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
        }


        public void Enter()
        {
            _sandboxUi = _uiFactory.CreateSandboxBattleUi();
            _sandboxUi.GoToScreen<SetupSandboxBattleUiScreen>();
            _sandboxUi.OnGameStateChangeEvent += OnGameStateChangeUiEventHandler;// TODO: Use Task and async/await
        }

        public void Exit()
        {
            _sandboxUi.OnGameStateChangeEvent -= OnGameStateChangeUiEventHandler;
        }

        private void OnGameStateChangeUiEventHandler(GameStateChangeEvent @event)
        {
            if (@event != GameStateChangeEvent.StartSandboxBattle)
                return;

            _stateMachine.EnterState<CreateBattleState>();
        }
    }
}
