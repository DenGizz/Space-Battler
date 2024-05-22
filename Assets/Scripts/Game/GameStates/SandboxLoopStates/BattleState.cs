using System;
using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.CoreServices.PersistentDataServices;
using Assets.Scripts.Infrastructure.Services.PersistentProgressServices;
using Assets.Scripts.StateMachines;
using Assets.Scripts.UI.Pause_Menu_UI;

namespace Assets.Scripts.Game.GameStates
{
    public class BattleState : IState
    {
        private readonly IUiElementsFactory _uiFactory;
        private readonly IBattleTickService _battleTickService;
        private readonly IBattleRunnerProvider _battleRunnerProvider;
        private readonly IProgressProvider _progressProvider;
        private readonly IPersistentDataService _persistentDataService;

        private readonly StateMachine _gameStateMachine;
        private BattleRunner _battleRunner;

        public BattleState(StateMachine gameStateMachine, 
            IUiElementsFactory uiFactory, IBattleTickService battleTickService,
            IBattleRunnerProvider battleRunnerProvider, IProgressProvider progressProvider, IPersistentDataService persistentDataService)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _battleTickService = battleTickService;
            _battleRunnerProvider = battleRunnerProvider;
            _progressProvider = progressProvider;
            _persistentDataService = persistentDataService;
        }

        public void Enter()
        {
            _battleRunner = _battleRunnerProvider.CurrentBattleRunner;
            _battleRunner.RunBattle();
            _battleTickService.IsPaused = false;
            _battleRunner.BattleEnded += OnBattleEndedEventHandler;
        }

        public void Exit()
        {
            _battleRunner.BattleEnded -= OnBattleEndedEventHandler;

        }

        private void OnBattleEndedEventHandler(object sender, BattleEndEventArgs args)
        {
            StopBattle();
            UpdateAndSaveProgress(args.BattleResult);


            _gameStateMachine.EnterState<ShowWinnerState>();
        }

        private void OnPauseContinueButtonClicked()
        {
            _battleTickService.IsPaused = !_battleTickService.IsPaused;
        }

        private void StopBattle()
        {
            _battleTickService.IsPaused = true;
            _battleTickService.IsPaused = true;
        }

        private void UpdateAndSaveProgress(BattleResult battleResult)
        {
            switch (battleResult)
            {
                case BattleResult.AllyTeamWin:
                    _progressProvider.PlayerProgressData.BattlesWon++;
                    break;
                case BattleResult.EnemyTeamWin:
                    _progressProvider.PlayerProgressData.BattlesLost++;
                    break;

                default:
                    throw new Exception();
            }

            _persistentDataService.SavePlayerProgressData(_progressProvider.PlayerProgressData);
        }
    }
}
