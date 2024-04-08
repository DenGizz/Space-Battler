using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.StateMachines;
using Assets.Scripts.UI;

namespace Assets.Scripts.Game.GameStates
{
    public class MainMenuState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly IBattleSetupProvider _battleSetupProvider;

        private MainMenuUI _mainMenuUi;

        public MainMenuState(StateMachine stateMachine, IUIFactory uiFactory, IBattleSetupProvider battleSetupProvider)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _battleSetupProvider = battleSetupProvider;
        }

        public void Enter()
        {
            _mainMenuUi = _uiFactory.CreateMainMenuUI();
            _mainMenuUi.OnStartBattleButtonClicked += OnStartBattleButtonClicked;
        }

        public void Exit()
        {
            _mainMenuUi.OnStartBattleButtonClicked -= OnStartBattleButtonClicked;
        }

        private void OnStartBattleButtonClicked()
        {
            if (_mainMenuUi.PlayerSetup.SpaceShipType == null || _mainMenuUi.EnemySetup.SpaceShipType == null)
                return;

            _battleSetupProvider.BattleSetup = new BattleSetup(_mainMenuUi.PlayerSetup, _mainMenuUi.EnemySetup);
            _stateMachine.EnterState<LoadBattleFieldSceneState>();
        }
    }
}
