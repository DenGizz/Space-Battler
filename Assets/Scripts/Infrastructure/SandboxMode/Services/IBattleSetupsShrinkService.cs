using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Gameplay.Factories
{
    public interface IBattleSetupsShrinkService
    {
        ISpaceShip UnShrinkSpaceShip(SpaceShipSetup setup);
    }
}