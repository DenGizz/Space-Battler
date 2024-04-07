using Assets.Scripts.Battle;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.StateMachine;
using Assets.Scripts.UI;

namespace Assets.Scripts.Game.GameStateMachine.GameStates
{
    public class MainMenuState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly IBattleSetupProvider _battleSetupProvider;

        private MainMenuUI _mainMenuUI;

        public MainMenuState(GameStateMachine gameStateMachine, IUIFactory uiFactory, IBattleSetupProvider battleSetupProvider)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _battleSetupProvider = battleSetupProvider;
        }

        public void Enter()
        {
            _mainMenuUI = _uiFactory.CreateMainMenuUI();
            _mainMenuUI.OnStartBattleButtonClicked += OnStartBattleButtonClicked;
        }

        public void Exit()
        {
            _mainMenuUI.OnStartBattleButtonClicked -= OnStartBattleButtonClicked;
        }

        private void OnStartBattleButtonClicked()
        {
            if (_mainMenuUI.PlayerSetup.SpaceShipType == null || _mainMenuUI.EnemySetup.SpaceShipType == null)
                return;

            _battleSetupProvider.BattleSetup = new BattleSetup(_mainMenuUI.PlayerSetup, _mainMenuUI.EnemySetup);
            _gameStateMachine.EnterState<LoadBattleFieldSceneState>();
        }
    }
}
