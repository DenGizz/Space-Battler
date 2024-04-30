using System;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;

namespace Assets.Scripts.Battles
{
    public class BattleSetup
    {
        public SpaceShipSetup PlayerSetup { get; set; }
        public SpaceShipSetup EnemySetup { get; set; }

        public BattleSetup(SpaceShipSetup playerSetup, SpaceShipSetup enemySetup)
        {
            PlayerSetup = playerSetup;
            EnemySetup = enemySetup;
        }
    }
}