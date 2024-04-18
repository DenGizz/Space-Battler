using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public interface IGameObjectRegistry
    {
        void RegisterWeaponGameObject(IWeapon weapon, GameObject gameObject);
        void RegisterSpaceShipGameObject(ISpaceShip spaceShip, GameObject gameObject);
        void RegisterProjectileGameObject(ProjectileBehaviour projectile, GameObject gameObject);

        void UnRegisterGameObject(GameObject gameObject);

        void UnRegisterAllProjectiles();

        GameObject GetSpaceShipGameObject(ISpaceShip spaceShip);
        GameObject GetWeaponGameObject(IWeapon weapon);
        GameObject GetProjectileGameObject(ProjectileBehaviour projectile);
    }
}
