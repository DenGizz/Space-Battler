using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Game.SandboxMode.BattleSetups;

namespace Assets.Scripts.Battles
{
    public class BattleSetup
    {
        public BattleTeamSetup PlayerTeamSetup { get; set; } = new BattleTeamSetup();
        public BattleTeamSetup EnemyTeamSetup { get; set; } = new BattleTeamSetup();
    }
}