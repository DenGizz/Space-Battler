using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface ISpaceShipFactory
    {
        ISpaceShip CreateSpaceShip(SpaceShipType type, Vector3 position, float zRotation);
    }
}