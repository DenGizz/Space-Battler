using Assets.Scripts.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
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

        public void RegisterGameObject(GameObject gameObject)
        {
            _spaceShipsGameObjects.Add(gameObject.GetComponent<ISpaceShip>(), gameObject);
        }

        public void UnregisterGameObject(GameObject gameObject)
        {
           _spaceShipsGameObjects.Remove(gameObject.GetComponent<ISpaceShip>());
        }
    }
}
