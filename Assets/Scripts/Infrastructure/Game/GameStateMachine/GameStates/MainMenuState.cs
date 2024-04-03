using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine.GameStates
{
    public class MainMenuState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;

        private MainMenuUI _mainMenuUI;

        public MainMenuState(GameStateMachine gameStateMachine, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            _mainMenuUI = _uiFactory.CreateMainMenuUI();
            _mainMenuUI.OnStartBattleButtonClicked += OnStartBattleButtonClicked;
        }

        public void Exit()
        {

        }

        private void OnStartBattleButtonClicked()
        {
            _gameStateMachine.EnterState<LoadBattleFieldSceneState>();
        }
    }
}
