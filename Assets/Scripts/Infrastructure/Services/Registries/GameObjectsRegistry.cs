using System.Collections.Generic;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public class GameObjectsRegistry : IGameObjectRegistry
    {
        private readonly Dictionary<ISpaceShip, GameObject> _spaceShipsGameObjects;
        private readonly Dictionary<IWeapon, GameObject> _weaponGameObjects;

        public GameObjectsRegistry()
        {
            _spaceShipsGameObjects = new Dictionary<ISpaceShip, GameObject>();
            _weaponGameObjects = new Dictionary<IWeapon, GameObject>();
        }

        public GameObject GetSpaceShipGameObject(ISpaceShip spaceShip)
        {
            return _spaceShipsGameObjects[spaceShip];
        }

        public GameObject GetWeaponGameObject(IWeapon weapon)
        {       
            return _weaponGameObjects[weapon];
        }

        public void RegisterGameObject(ISpaceShip spaceShip, GameObject gameObject)
        {
            _spaceShipsGameObjects.Add(spaceShip, gameObject);
        }

        public void RegisterGameObject(IWeapon weapon, GameObject gameObject)
        {
            _weaponGameObjects.Add(weapon, gameObject);  
        }

        public void UnRegisterGameObject(GameObject gameObject)
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
