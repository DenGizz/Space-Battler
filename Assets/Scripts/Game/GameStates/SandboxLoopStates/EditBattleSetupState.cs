using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.CoreServices.PersistentDataServices;
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
        private readonly IBattleSetupProvider _battleSetupProvider;
        private readonly IPersistentDataService _persistentDataService;

        private Ui _sandboxUi;
        private SetupSandboxBattleUiScreen _sandboxScreen;

        public EditBattleSetupState(StateMachine stateMachine, IUiFactory uiFactory, IBattleSetupProvider battleSetupProvider, IPersistentDataService persistentDataService)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _battleSetupProvider = battleSetupProvider;
            _persistentDataService = persistentDataService;
        }

        public void Enter()
        {
            _sandboxUi = _uiFactory.CreateSandboxBattleUi();
            _sandboxScreen = _sandboxUi.GoToScreen<SetupSandboxBattleUiScreen>();
            _sandboxScreen.SetBattleSetupForEditing(_battleSetupProvider.BattleSetup);
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

            //_persistentDataService.SaveBattleSetup(_battleSetupProvider.BattleSetup);

            _stateMachine.EnterState<CreateBattleState>();
        }
    }
}
