using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Game.SandboxMode.BattleSetups;

namespace Assets.Scripts.Battles
{
    public class BattleSetup
    {
        public BattleTeamSetup PlayerTeamSetup { get; set; }
        public BattleTeamSetup EnemyTeamSetup { get; set; }

        public SpaceShipSetup PlayerSetup { get; set; }
        public SpaceShipSetup EnemySetup { get; set; }

        public BattleSetup(SpaceShipSetup playerSetup, SpaceShipSetup enemySetup)
        {
            PlayerSetup = playerSetup;
            EnemySetup = enemySetup;
        }
    }
}