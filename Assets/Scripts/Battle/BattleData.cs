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
        public ISpaceShip PlayerSpaceShip { get; set; }
        public ISpaceShip EnemySpaceShip { get; set; }

        public BattleData() { }

        public BattleData(ISpaceShip playerUnit, ISpaceShip enemyUnit)
        {
            PlayerSpaceShip = playerUnit;
            EnemySpaceShip = enemyUnit;
        }
    }
}
