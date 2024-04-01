using Assets.Scripts.Units;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public interface ISpaceShipsGameObjectRegistry
    {
        void RegisterGameObject(ISpaceShip spaceShip, GameObject gameObject);
        void UnregisterGameObject(GameObject gameObject);

        GameObject GetSpaceShipGameObject(ISpaceShip spaceShip);
    }
}
