using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class BattleData
    {
        public ISpaceShip PlayerSpaceShip { get; set; }
        public ISpaceShip EnemySpaceShip { get; set; }

        public ICombatAI PlayerAI { get;  set; }
        public ICombatAI EnemyAI { get;  set; }

        public bool IsBattleStarted { get;  set; }
        public bool IsBattleEnded { get;  set; }

        public BattleData() { }

        public BattleData(ISpaceShip playerUnit, ISpaceShip enemyUnit, 
            ICombatAI playerAI, ICombatAI enemyAI, bool isBattleStarted, bool isBattleEnded)
        {
            PlayerSpaceShip = playerUnit;
            EnemySpaceShip = enemyUnit;
            PlayerAI = playerAI;
            EnemyAI = enemyAI;
            IsBattleStarted = isBattleStarted;
            IsBattleEnded = isBattleEnded;
        }
    }
}
