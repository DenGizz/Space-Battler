using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.Core.Services.PersistentDataServices;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using Assets.Scripts.Infrastructure.Ui.Providers;
using Assets.Scripts.UI.Uis;
using Assets.Scripts.UI.UiScreens.SandboxModeUiScreens;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Ui.Services;

namespace Assets.Scripts.Game.GameStates.SandboxLoopStates
{
    public class EditBattleSetupState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IBattleSetupProvider _battleSetupProvider;
        private readonly IPersistentDataService _persistentDataService;
        private readonly IUisProvider _uisProvider;
        private readonly IAudioPlayer _audioPlayer;
        private readonly IUiWindowsService _uiWindowsService;

        private Ui _sandboxUi;


        private SetupSandboxBattleUiScreen _sandboxScreen;

        public EditBattleSetupState(StateMachine stateMachine, IBattleSetupProvider battleSetupProvider,
            IPersistentDataService persistentDataService, IUisProvider uisProvider, IAudioPlayer audioPlayer,
            IUiWindowsService uiWindowsService)
        {
            _stateMachine = stateMachine;
            _battleSetupProvider = battleSetupProvider;
            _persistentDataService = persistentDataService;
            _uisProvider = uisProvider;
            _audioPlayer = audioPlayer;
            _uiWindowsService = uiWindowsService;
        }


        public void Enter()
        {
            _audioPlayer.UnmuteMainMenuMusic();
            _sandboxUi = _uisProvider.SandboxModeUi;
            _sandboxScreen = _sandboxUi.GoToScreen<SetupSandboxBattleUiScreen>();
            _sandboxScreen.SetBattleSetupForEditing(_battleSetupProvider.BattleSetup);
            _uisProvider.ChangeLanguageOverlay.IsVisible = true;
            _sandboxUi.OnGameStateChangeEvent += OnGameStateChangeUiEventHandler;// TODO: Use Task and async/await
        }

        public void Exit()
        {
            _sandboxUi.OnGameStateChangeEvent -= OnGameStateChangeUiEventHandler;
            _uiWindowsService.CloseAllWindows();
        }

        private void OnGameStateChangeUiEventHandler(GameStateChangeEvent @event)
        {
            if (@event != GameStateChangeEvent.StartSandboxBattle)
                return;

            _persistentDataService.SaveBattleSetup(_battleSetupProvider.BattleSetup);
            _stateMachine.EnterState<CreateBattleState>();
        }
    }
}
