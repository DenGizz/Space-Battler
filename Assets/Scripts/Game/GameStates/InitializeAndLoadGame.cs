using Assets.Scripts.Battles;
using Assets.Scripts.Progress;
using Assets.Scripts.StateMachines;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Infrastructure.Core.Services.PersistentDataServices;
using Assets.Scripts.Infrastructure.Core.Services.PersistentProgressServices;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using Assets.Scripts.Infrastructure.Localization;
using Assets.Scripts.Infrastructure.Core.Services;

namespace Assets.Scripts.Game.GameStates
{
    public class InitializeAndLoadGame : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IBattleSetupProvider _battleSetupProvider;
        private readonly IProgressProvider _progressProvider;
        private readonly IPersistentDataService _persistentDataService;
        private readonly ILocalizationDb _localizationDb;
        private readonly IAudioPlayer _audioPlayer;

        public InitializeAndLoadGame(StateMachine stateMachine, IBattleSetupProvider battleSetupProvider, 
            IPersistentDataService persistentDataService, 
            IProgressProvider progressProvider, ILocalizationDb localizationDb, IAudioPlayer audioPlayer)
        {
            _stateMachine = stateMachine;
            _battleSetupProvider = battleSetupProvider;
            _persistentDataService = persistentDataService;
            _progressProvider = progressProvider;
            _localizationDb = localizationDb;
            _audioPlayer = audioPlayer;
        }

        public void Enter()
        {
            _localizationDb.LoadDb();
            _persistentDataService.Initialize();
            _audioPlayer.Initialize();

            LoadOrCreateBattleSetup();
            LoadOrCreateProgress();
            _stateMachine.EnterState<CreateUiOverlaysState>();
        }

        public void Exit()
        {

        }

        private void LoadOrCreateBattleSetup()
        {
            if (_persistentDataService.IsBattleSetupStored())
            {
                _battleSetupProvider.BattleSetup = _persistentDataService.LoadBattleSetup();
            }
            else
            {
                BattleSetup battleSetup = new BattleSetup();
                _persistentDataService.SaveBattleSetup(battleSetup);
                _battleSetupProvider.BattleSetup = battleSetup;
            }
        }

        private void LoadOrCreateProgress()
        {
            if(_persistentDataService.IsPlayerProgressDataStored())
            {
                _progressProvider.PlayerProgressData = _persistentDataService.LoadPlayerProgressData();
            }
            else
            {
                PlayerProgressData playerProgressData = new PlayerProgressData();
                _persistentDataService.SavePlayerProgressData(playerProgressData);
                _progressProvider.PlayerProgressData = playerProgressData;
            }
        }
    }
}
