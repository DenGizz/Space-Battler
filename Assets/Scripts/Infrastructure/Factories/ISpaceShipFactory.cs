using Assets.Scripts.SpaceShip;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface ISpaceShipFactory
    {
        ISpaceShip CreateSpaceShip(SpaceShipType type, Vector3 position, float zRotation, Color color);
    }
}