﻿using Assets.Scripts.AI.UnitsAI;
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

        public ICombatAI PlayerAI { get;  set; }
        public ICombatAI EnemyAI { get;  set; }

        public BattleData() { }

        public BattleData(ISpaceShip playerUnit, ISpaceShip enemyUnit, 
            ICombatAI playerAI, ICombatAI enemyAI)
        {
            PlayerSpaceShip = playerUnit;
            EnemySpaceShip = enemyUnit;
            PlayerAI = playerAI;
            EnemyAI = enemyAI;
        }
    }
}
