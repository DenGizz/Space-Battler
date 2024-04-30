using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.CoreServices;
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
        private readonly IPersistentDataService _persistentDataService;

        public InitializeAndLoadGame(StateMachine stateMachine, IBattleSetupProvider battleSetupProvider, IPersistentDataService persistentDataService)
        {
            _stateMachine = stateMachine;
            _battleSetupProvider = battleSetupProvider;
            _persistentDataService = persistentDataService;
        }

        public void Enter()
        {
            _persistentDataService.Initialize();

            LoadOrCreateBattleSetup();
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
    }
}
