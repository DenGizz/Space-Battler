using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShip;
using Assets.Scripts.StateMachine;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine.GameStates
{
    public class BattleState : IState
    {
        private readonly IBattleObserver _battleObserver;
        private readonly IBattleDataProvider _battleDataProvider;
        private readonly ICombatAiRegistry _combatAiRegistry;


        private readonly GameStateMachine GameStateMachine;

        public BattleState(GameStateMachine gameStateMachine, IBattleObserver battleObserver, IBattleDataProvider battleDataProvider, ICombatAiRegistry combatAiRegistry)
        {
            GameStateMachine = gameStateMachine;
            _battleObserver = battleObserver;
            _battleDataProvider = battleDataProvider;
            _combatAiRegistry = combatAiRegistry;
        }

        public void Enter()
        {
            StartBattle();
            _battleObserver.OnWinnerDetermined += OnWinnerDeterminedEventHandler;
        }

        public void Exit()
        {
            _battleObserver.OnWinnerDetermined -= OnWinnerDeterminedEventHandler;
        }

        private void OnWinnerDeterminedEventHandler(ISpaceShip winner)
        {
            StopBattle();
            GameStateMachine.EnterState<CleanUpBattleState>();
        }

        private void StartBattle()
        {
            _battleObserver.StartObserve(_battleDataProvider.CurrentBattleData);

            ICombatAI playerAi = _combatAiRegistry.GetAI(_battleDataProvider.CurrentBattleData.PlayerSpaceShip);
            ICombatAI enemyAi = _combatAiRegistry.GetAI(_battleDataProvider.CurrentBattleData.EnemySpaceShip);

            playerAi.SetTarget(_battleDataProvider.CurrentBattleData.EnemySpaceShip);
            enemyAi.SetTarget(_battleDataProvider.CurrentBattleData.PlayerSpaceShip);

            playerAi.StartCombat();
            enemyAi.StartCombat();
        }

        private void StopBattle()
        {
            ICombatAI playerAi = _combatAiRegistry.GetAI(_battleDataProvider.CurrentBattleData.PlayerSpaceShip);
            ICombatAI enemyAi = _combatAiRegistry.GetAI(_battleDataProvider.CurrentBattleData.EnemySpaceShip);

            playerAi.StopCombat();
            enemyAi.StopCombat();
        }

        private void ResumeBattle()
        {
            ICombatAI playerAi = _combatAiRegistry.GetAI(_battleDataProvider.CurrentBattleData.PlayerSpaceShip);
            ICombatAI enemyAi = _combatAiRegistry.GetAI(_battleDataProvider.CurrentBattleData.EnemySpaceShip);

            playerAi.StartCombat();
            enemyAi.StartCombat();
        }
    }
}
