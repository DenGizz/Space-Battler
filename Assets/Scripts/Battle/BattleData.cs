using Assets.Scripts.AI.UnitsAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.SpaceShip;

namespace Assets.Scripts
{
    public class BattleData
    {
        public ISpaceShip PlayerSpaceShip { get; }
        public ISpaceShip EnemySpaceShip { get;}
        public ICombatAI PlayerCombatAi { get; }
        public ICombatAI EnemyCombatAi { get; }

        public BattleData( ISpaceShip playerSpaceShip, ISpaceShip enemySpaceShip, ICombatAI playerCombatAi, ICombatAI enemyCombatAi)
        {
            PlayerSpaceShip = playerSpaceShip;
            EnemySpaceShip = enemySpaceShip;
            PlayerCombatAi = playerCombatAi;
            EnemyCombatAi = enemyCombatAi;
        }
    }
}
