using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Entities.Projectiles;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using UnityEngine;
using Assets.Scripts.ScriptableObjects;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
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
