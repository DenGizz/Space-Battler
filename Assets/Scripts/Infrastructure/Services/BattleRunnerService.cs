using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services.Factories;
using Assets.Scripts.Units;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public class BattleRunnerService 
    {
        ICombatUnitFactory _combatUnitFactory;
        ICombatAIRegistry _combatAIRegistry;
        IBattleObserver _battleObserver;

        public BattleData CurrentBattle { get; private set; }

        public BattleRunnerService(ICombatUnitFactory combatUnitFactory, ICombatAIRegistry combatAIRegistry, IBattleObserver battleObserver)
        {
            _combatUnitFactory = combatUnitFactory;
            _combatAIRegistry = combatAIRegistry;
            _battleObserver = battleObserver;
            _battleObserver.OnWinerDetermined += OnWinerDeterminedEventHandler;
        }

        public void SetupBattle()
        {
            //Instantiate units
            ICombatUnit player = _combatUnitFactory.CreatePlayerSpaceShip();
            ICombatUnit enemy = _combatUnitFactory.CreateEnemySpaceShip();
            //Find target for each combat unit
            ICombatAI playerAI = _combatAIRegistry.GetAI(player);
            ICombatAI enemyAI = _combatAIRegistry.GetAI(enemy);
            //Setup targets in unit ai
            playerAI.SetTarget(enemy);
            enemyAI.SetTarget(player);

            CurrentBattle = new BattleData(player, enemy, playerAI, enemyAI, false, false);
        }

        public void StartBattle()
        {
            _battleObserver.StartObserve(CurrentBattle);
            //Enable combat ai battle mode
            foreach (ICombatAI ai in _combatAIRegistry.CombatAIs)
                   ai.StartCombat();
        }

        public void StopBattle()
        {
            _battleObserver.StopObserve();
            //Disable combat ai battle mode
            foreach (ICombatAI ai in _combatAIRegistry.CombatAIs)
                ai.StopCombat();
        }

        public void CleanUpBattle()
        {
            //Destroy units
            //Free memory
            //Destroy projectiles
        }

        private void OnWinerDeterminedEventHandler(ICombatUnit winner)
        {
            StopBattle();
            Debug.Log("Winner is " + winner);
        }
    }
}