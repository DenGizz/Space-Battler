using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.PersistentProgressServices;
using Assets.Scripts.Progress;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.GameStates
{
    public class InitializeAndLoadGame : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IBattleSetupProvider _battleSetupProvider;
        private readonly IProgressProvider _progressProvider;
        private readonly IPersistentDataService _persistentDataService;

        public InitializeAndLoadGame(StateMachine stateMachine, IBattleSetupProvider battleSetupProvider, IPersistentDataService persistentDataService, IProgressProvider progressProvider)
        {
            _stateMachine = stateMachine;
            _battleSetupProvider = battleSetupProvider;
            _persistentDataService = persistentDataService;
            _progressProvider = progressProvider;
        }

        public void Enter()
        {
            _persistentDataService.Initialize();

            LoadOrCreateBattleSetup();
            LoadOrCreateProgress();
            _stateMachine.EnterState<LoadMainMenuSceneState>();
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
                SpaceShipSetup playerSetup = new SpaceShipSetup();
                SpaceShipSetup enemySetup = new SpaceShipSetup();

                BattleSetup battleSetup = new BattleSetup(playerSetup, enemySetup);
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
