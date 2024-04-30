using System.Collections;
using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.StateMachines;
using UnityEngine;

namespace Assets.Scripts.Game.GameStates
{
    public class WinnerDetermined : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IBattleProvider _battleProvider;
        private readonly IUiFactory _uiFactory;

        private BattleWinnerUI _winnerUi;

        public WinnerDetermined(StateMachine stateMachine, IBattleProvider battleProvider, IUiFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _battleProvider = battleProvider;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            Battle battle = _battleProvider.CurrentBattle;
            _winnerUi = _uiFactory.CreateWinnerUi();
            _winnerUi.SetWinner(battle.Winner, battle.Winner == battle.BattleData.PlayerSpaceShip);
            _winnerUi.OnReturnMainMenuButtonPressed += OnReturnMainMenuButtonPressedEventHandler;
        }

        public void Exit()
        {
            _winnerUi.OnReturnMainMenuButtonPressed -= OnReturnMainMenuButtonPressedEventHandler;
        }

        private void OnReturnMainMenuButtonPressedEventHandler()
        {
            _stateMachine.EnterState<CleanUpBattleState>();
        }
    }
}