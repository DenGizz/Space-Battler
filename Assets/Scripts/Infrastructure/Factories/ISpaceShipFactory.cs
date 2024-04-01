using Assets.Scripts.Units;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface ISpaceShipFactory
    {
        ISpaceShip CreatePlayerSpaceShip(Vector3 position);
        ISpaceShip CreateEnemySpaceShip(Vector3 position);
    }
}