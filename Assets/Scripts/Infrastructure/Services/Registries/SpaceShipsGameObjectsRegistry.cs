using System.Collections.Generic;
using Assets.Scripts.SpaceShip;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public class SpaceShipsGameObjectsRegistry : ISpaceShipsGameObjectRegistry
    {
        private Dictionary<ISpaceShip, GameObject> _spaceShipsGameObjects;

        public SpaceShipsGameObjectsRegistry()
        {
            _spaceShipsGameObjects = new Dictionary<ISpaceShip, GameObject>();
        }

        public GameObject GetSpaceShipGameObject(ISpaceShip spaceShip)
        {
            return _spaceShipsGameObjects[spaceShip];
        }

        public void RegisterGameObject(ISpaceShip spaceShip, GameObject gameObject)
        {
            _spaceShipsGameObjects.Add(spaceShip, gameObject);
        }

        public void UnregisterGameObject(GameObject gameObject)
        {      
            foreach (var pair in _spaceShipsGameObjects)
            {
                if (pair.Value == gameObject)
                {
                    _spaceShipsGameObjects.Remove(pair.Key);
                    break;
                }
            }
        }
    }
}
