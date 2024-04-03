using Assets.Scripts.SpaceShip;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface ISpaceShipFactory
    {
        ISpaceShip CreateSpaceShip(Vector3 position, float zRotation, Color color);
    }
}