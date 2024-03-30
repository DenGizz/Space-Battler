using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services.Factories;
using Assets.Scripts.Units;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public class BattleService 
    {
        ICombatUnitFactory _combatUnitFactory;
        ICombatAIRegistry _combatAIRegistry;

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
        }

        public void StartBattle()
        {
            //Enable combat ai battle mode
            foreach(ICombatAI ai in _combatAIRegistry.CombatAIs)
                   ai.StartCombat();
        }

        public void StopBattle()
        {
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
    }
}