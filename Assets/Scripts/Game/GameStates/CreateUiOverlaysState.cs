using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.Infrastructure.Ui.Providers;
using Assets.Scripts.Infrastructure.Ui.Services;
using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Game.GameStates
{
    public class CreateUiOverlaysState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IUiFactory _uiFactory;
        private readonly IUisProvider _uisProvider;

        public CreateUiOverlaysState(StateMachine stateMachine, IUiFactory uiFactory, IUisProvider uisProvider)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _uisProvider = uisProvider;
        }

        public void Enter()
        {
            _uisProvider.ChangeLanguageOverlay = _uiFactory.CreateChangeLanguageUiScreenOverlay();
            _uisProvider.PopoutMessagesOverlay = _uiFactory.CreatePopoutMessagesOverlay();
            _stateMachine.EnterState<LoadMainMenuSceneState>();
        }

        public void Exit()
        {

        }
    }
}
