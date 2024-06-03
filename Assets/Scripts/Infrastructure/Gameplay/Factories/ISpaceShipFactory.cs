using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Gameplay.Factories
{
    public interface ISpaceShipFactory
    {
        ISpaceShip CreateSpaceShip(SpaceShipType type, Vector3 position = default, float zRotation = 0);
    }
}