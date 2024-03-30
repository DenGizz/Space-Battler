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
        public ICombatUnit PlayerUnit { get; private set; }
        public ICombatUnit EnemyUnit { get; private set; }

        public ICombatAI PlayerAI { get; private set; }
        public ICombatAI EnemyAI { get; private set; }

        public bool IsBattleStarted { get; private set; }
        public bool IsBattleEnded { get; private set; }

        public BattleData() { }

        public void AddPlayer(ICombatUnit playerUnit, ICombatAI playerAI)
        {
            PlayerUnit = playerUnit;
            PlayerAI = playerAI;
        }

        public void AddEnemy(ICombatUnit enemyUnit, ICombatAI enemyAI)
        {
            EnemyUnit = enemyUnit;
            EnemyAI = enemyAI;
        }
    }
}
