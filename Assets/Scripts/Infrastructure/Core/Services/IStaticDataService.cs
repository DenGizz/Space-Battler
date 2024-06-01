using System.Collections.Generic;
using Assets.Scripts.Entities.Projectiles;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public interface IStaticDataService
    {
        Sprite GetSpriteFor(SpaceShipType spaceShipType);
        Sprite GetSpriteFor(WeaponType weaponType);
        IEnumerable<WeaponDescriptor> GetWeaponDescriptors();
        IEnumerable<SpaceShipDescriptor> GetSpaceShipDescriptors();
        IEnumerable<ProjectileDescriptor> GetProjectilesDescriptors();
        WeaponDescriptor GetWeaponDescriptor(WeaponType weaponType);
        SpaceShipDescriptor GetSpaceShipDescriptor(SpaceShipType spaceShipType);
        ProjectileDescriptor GetProjectileDescriptor(ProjectileType projectileType);
    }
}
