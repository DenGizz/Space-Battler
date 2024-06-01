using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.Weapons;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Gameplay.Registries
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
