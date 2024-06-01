using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IShrinkService
    {
        ISpaceShip UnShrinkSpaceShip(SpaceShipSetup setup, Vector3 position, float zRotation);
    }
}