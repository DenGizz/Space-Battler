using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShip;
using Assets.Scripts.StateMachine;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine
{
    public class BattleRunningState : IState
    {
        private readonly IBattleObserver _battleObserver;
        private readonly ICombatAIRegistry _combatAIRegistry;
        private readonly GameStateMachine GameStateMachine;

        public BattleRunningState(GameStateMachine gameStateMachine, IBattleObserver battleObserver, ICombatAIRegistry combatAIRegistry)
        {
            GameStateMachine = gameStateMachine;
            _battleObserver = battleObserver;
            _combatAIRegistry = combatAIRegistry;
        }

        public void Enter()
        {
            StartBattle();
            _battleObserver.OnWinnerDetermined += OnWinerDeterminedEventHandler;
        }

        public void Exit()
        {
            _battleObserver.OnWinnerDetermined -= OnWinerDeterminedEventHandler;
        }

        private void StartBattle()
        {
            //TODO: Create BattleData provider service ???
            BattleData battleData = GameStateMachine.BattleData;
            _battleObserver.StartObserve(battleData);
            //Enable combat ai battle mode
            foreach (ICombatAI ai in _combatAIRegistry.CombatAIs)
                ai.StartCombat();
        }

        private void StopBattle()
        {
            _battleObserver.StopObserve();
            //Disable combat ai battle mode
            foreach (ICombatAI ai in _combatAIRegistry.CombatAIs)
                ai.StopCombat();
        }

        private void OnWinerDeterminedEventHandler(ISpaceShip winner)
        {
            StopBattle();
            GameStateMachine.EnterState<CleanUpBattleState>();
        }
    }
}
