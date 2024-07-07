using Assets.Scripts.Battles;
using Assets.Scripts.StateMachines;
using System;
using Assets.Scripts.Infrastructure.Core.Services.PersistentDataServices;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.UI.Uis;
using Assets.Scripts.UI.UiScreens.MainMenuUiScreens;
using Assets.Scripts.Infrastructure.Localization;

namespace Assets.Scripts.Game.GameStates
{
    public class MainMenuState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IUiFactory _uiFactory;
        private readonly IBattleSetupProvider _battleSetupProvider;
        private readonly IPersistentDataService _persistentDataService;
        private readonly IPopoutMessagesService _popoutMessagesService;
        private readonly ILocalizationService _localizationService;

        private Ui _mainMenuUi;

        public MainMenuState(StateMachine stateMachine, IUiFactory uiFactory, IBattleSetupProvider battleSetupProvider, 
            IPersistentDataService persistentDataService, IPopoutMessagesService popoutMessagesService, ILocalizationService localizationService)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _battleSetupProvider = battleSetupProvider;
            _persistentDataService = persistentDataService;
            _popoutMessagesService = popoutMessagesService;
            _localizationService = localizationService;
        }


        public void Enter()
        {
            _mainMenuUi = _uiFactory.CreateMainMenuUi();
            _mainMenuUi.GoToScreen<MainMenuButtonsUiScreen>();
            _mainMenuUi.OnGameStateChangeEvent += OnGameStateChangeUiEventHandler;
        }

        public void Exit()
        {
            _mainMenuUi.OnGameStateChangeEvent -= OnGameStateChangeUiEventHandler;
        }

        private void OnGameStateChangeUiEventHandler(GameStateChangeEvent @event)
        {
            if(@event == GameStateChangeEvent.EnterStoryMode)
            {
                _popoutMessagesService.SendMessage(
                    _localizationService.GetLocalizedString("story_mode_not_avaliable"));
                return;
            }

            if (@event != GameStateChangeEvent.EnterSandboxMode)
                return;

            _persistentDataService.SaveBattleSetup(_battleSetupProvider.BattleSetup);
            _battleSetupProvider.BattleSetup = _battleSetupProvider.BattleSetup;
            _stateMachine.EnterState<LoadBattleFieldSceneState>();
        }
    }
}
