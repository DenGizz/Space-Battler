using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.SpaceShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Battle
{
    public class Battle
    {
        public BattleData BattleData { get; }

        public Battle(ISpaceShip playerSpaceShip, ISpaceShip enemySpaceShip, ICombatAI playerAi, ICombatAI enemyAi)
        {
            BattleData = new BattleData(playerSpaceShip, enemySpaceShip, playerAi, enemyAi);
        }

        public void StartBattle()
        {
            BattleData.PlayerCombatAi.SetTarget(BattleData.EnemySpaceShip);
            BattleData.EnemyCombatAi.SetTarget(BattleData.PlayerSpaceShip);

            BattleData.PlayerCombatAi.StartCombat();
            BattleData.EnemyCombatAi.StartCombat();
        }

        public void StopBattle()
        {
            BattleData.PlayerCombatAi.StopCombat();
            BattleData.EnemyCombatAi.StopCombat();
        }

        public void ResumeBattle()
        {
            BattleData.PlayerCombatAi.StartCombat();
            BattleData.EnemyCombatAi.StartCombat();
        }
    }
}
