using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Game.SandboxMode.BattleSetups;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Gameplay.Factories
{
    public interface IBattleSetupsShrinkService
    {
        ISpaceShip UnShrinkSpaceShip(SpaceShipSetup setup);
        BattleTeam UnShrinkBattleTeamSetup(BattleTeamSetup setup);
        BattleRunner UnShrinkBattleSetup(BattleSetup setup);
    }
}