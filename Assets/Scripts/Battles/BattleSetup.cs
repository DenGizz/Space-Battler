using Assets.Scripts.SpaceShips.SpaceShipConfigs;

namespace Assets.Scripts.Battles
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