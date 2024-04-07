using System.Collections;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.Battle
{
    public class BattleSetup
    {
        public SpaceShipSetup PlayerSetup { get; }
        public SpaceShipSetup EnemySetup { get; }

        public BattleSetup(SpaceShipSetup playerSetup, SpaceShipSetup enemySetup)
        {
            PlayerSetup = playerSetup;
            EnemySetup = enemySetup;
        }
    }
}