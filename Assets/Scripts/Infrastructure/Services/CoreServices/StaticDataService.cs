using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Entities.Projectiles;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetsProvider _assetsProvider;

        public StaticDataService(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public Sprite GetSpriteFor(SpaceShipType spaceShipType)
        {
            return _assetsProvider.GetSpaceShipDescriptor(spaceShipType).Sprite;
        }

        public Sprite GetSpriteFor(WeaponType weaponType)
        {
            return _assetsProvider.GetWeaponDescriptor(weaponType).Sprite;
        }

        public IEnumerable<WeaponDescriptor> GetWeaponDescriptors()
        {
            return _assetsProvider.GetWeaponDescriptors();
        }

        public IEnumerable<SpaceShipDescriptor> GetSpaceShipDescriptors()
        {
            return _assetsProvider.GetSpaceShipsDescriptors();
        }

        public IEnumerable<ProjectileDescriptor> GetProjectilesDescriptors()
        {
            return _assetsProvider.GetProjectileDescriptors();
        }

        public WeaponDescriptor GetWeaponDescriptor(WeaponType weaponType)
        {
            return _assetsProvider.GetWeaponDescriptor(weaponType);
        }

        public SpaceShipDescriptor GetSpaceShipDescriptor(SpaceShipType spaceShipType)
        {
            return _assetsProvider.GetSpaceShipDescriptor(spaceShipType);
        }

        public ProjectileDescriptor GetProjectileDescriptor(ProjectileType projectileType)
        {
            return _assetsProvider.GetProjectileDescriptor(projectileType);
        }
    }
}
