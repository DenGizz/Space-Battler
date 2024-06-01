using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.Weapons;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public class GameObjectsRegistry : IGameObjectRegistry
    {
        private readonly Dictionary<ISpaceShip, GameObject> _spaceShipsGameObjects;
        private readonly Dictionary<IWeapon, GameObject> _weaponGameObjects;
        private readonly Dictionary<ProjectileBehaviour, GameObject> _projectileGameObjects;

        public GameObjectsRegistry()
        {
            _spaceShipsGameObjects = new Dictionary<ISpaceShip, GameObject>();
            _weaponGameObjects = new Dictionary<IWeapon, GameObject>();
            _projectileGameObjects = new Dictionary<ProjectileBehaviour, GameObject>();
        }

        public GameObject GetSpaceShipGameObject(ISpaceShip spaceShip)
        {
            return _spaceShipsGameObjects[spaceShip];
        }

        public GameObject GetWeaponGameObject(IWeapon weapon)
        {       
            return _weaponGameObjects[weapon];
        }

        public GameObject GetProjectileGameObject(ProjectileBehaviour projectile)
        {
            return _projectileGameObjects[projectile];
        }

        public void RegisterProjectileGameObject(ProjectileBehaviour projectile, GameObject gameObject)
        {
            _projectileGameObjects.Add(projectile, gameObject);
        }

        public void RegisterSpaceShipGameObject(ISpaceShip spaceShip, GameObject gameObject)
        {
            _spaceShipsGameObjects.Add(spaceShip, gameObject);
        }

        public void RegisterWeaponGameObject(IWeapon weapon, GameObject gameObject)
        {
            _weaponGameObjects.Add(weapon, gameObject);  
        }

        public void UnRegisterAllProjectiles()
        {
            _projectileGameObjects.Clear();
        }

        public void UnRegisterGameObject(GameObject gameObject)
        {      
            if (_spaceShipsGameObjects.ContainsValue(gameObject))
            {
                var spaceShip = _spaceShipsGameObjects.FirstOrDefault(x => x.Value == gameObject).Key;
                _spaceShipsGameObjects.Remove(spaceShip);
            }
            else if (_weaponGameObjects.ContainsValue(gameObject))
            {
                var weapon = _weaponGameObjects.FirstOrDefault(x => x.Value == gameObject).Key;
                _weaponGameObjects.Remove(weapon);
            }
            else if (_projectileGameObjects.ContainsValue(gameObject))
            {
                var projectile = _projectileGameObjects.FirstOrDefault(x => x.Value == gameObject).Key;
                _projectileGameObjects.Remove(projectile);
            }
        }
    }
}
