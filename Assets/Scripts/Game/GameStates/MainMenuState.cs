using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.StateMachines;
using Assets.Scripts.UI;

namespace Assets.Scripts.Game.GameStates
{
    public class MainMenuState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IUiFactory _uiFactory;
        private readonly IBattleSetupProvider _battleSetupProvider;
        private readonly IPersistentDataService _persistentDataService;

        private MainMenuUI _mainMenuUi;

        public MainMenuState(StateMachine stateMachine, IUiFactory uiFactory, IBattleSetupProvider battleSetupProvider, 
            IPersistentDataService persistentDataService)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _battleSetupProvider = battleSetupProvider;
            _persistentDataService = persistentDataService;
        }


        public void Enter()
        {
            _mainMenuUi = _uiFactory.CreateMainMenuUi();
            _mainMenuUi.LoadBattleSetupInUi(_battleSetupProvider.BattleSetup);
            _mainMenuUi.OnStartBattleButtonClicked += OnStartBattleButtonClicked;
        }

        public void Exit()
        {
            _mainMenuUi.OnStartBattleButtonClicked -= OnStartBattleButtonClicked;
        }

        private void OnStartBattleButtonClicked()
        {
            BattleSetup battleSetup = _mainMenuUi.CreateSetupFromUi();

            if (!BattleSetupValidator.IsBattleSetupValidForStartBattle(battleSetup))
                return;

            _persistentDataService.SaveBattleSetup(battleSetup);
            _battleSetupProvider.BattleSetup = battleSetup;
            _stateMachine.EnterState<LoadBattleFieldSceneState>();
        }
    }
}
