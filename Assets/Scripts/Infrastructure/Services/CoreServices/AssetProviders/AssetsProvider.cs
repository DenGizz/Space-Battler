using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Assets.Scripts.Entities.Projectiles;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Config;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class AssetsProvider : IAssetsProvider
    {
        private const string UiPrefabsBanldeAssetName = "UiPrefabsBanle";
        private const string StaticDataPath = "StaticData";
        private const string SpaceShipsStaticDataPath = "SpaceShipDescriptors";
        private const string WeaponStaticDataPath = "WeaponDescriptors";
        private const string ProjectileDataPath = "ProjectileDescriptors";

        private readonly Dictionary<SpaceShipType, SpaceShipDescriptor> _loadedSpaceShipDescriptorsCache;
        private readonly Dictionary<WeaponType, WeaponDescriptor> _loadedWeaponDescriptorsCache;
        private readonly Dictionary<ProjectileType, ProjectileDescriptor> _loadedProjectileDescriptorsCache;

        public AssetsProvider()
        {
            _loadedSpaceShipDescriptorsCache = new Dictionary<SpaceShipType, SpaceShipDescriptor>();
            _loadedWeaponDescriptorsCache = new Dictionary<WeaponType, WeaponDescriptor>();
            _loadedProjectileDescriptorsCache = new Dictionary<ProjectileType, ProjectileDescriptor>();
        }

        public GameObject GetSpaceShipPrefab(SpaceShipType spaceShipType)
        {
            return GetSpaceShipDescriptor(spaceShipType).Prefab;
        }

        public GameObject GetWeaponPrefab(WeaponType weaponType)
        {
            return GetWeaponDescriptor(weaponType).Prefab;
        }

        public IEnumerable<SpaceShipDescriptor> GetSpaceShipsDescriptors()
        {
            if(_loadedSpaceShipDescriptorsCache.Count != 0)
                return _loadedSpaceShipDescriptorsCache.Values;

            string path = Path.Combine(StaticDataPath, SpaceShipsStaticDataPath);
            SpaceShipDescriptor[] descriptors = Resources.LoadAll<SpaceShipDescriptor>(path);

            foreach (SpaceShipDescriptor descriptor in descriptors)
                _loadedSpaceShipDescriptorsCache.Add(descriptor.SpaceShipType, descriptor);

            return descriptors;
        }

        public IEnumerable<WeaponDescriptor> GetWeaponDescriptors()
        {
            if(_loadedWeaponDescriptorsCache.Count != 0)
                return _loadedWeaponDescriptorsCache.Values;

            string path = Path.Combine(StaticDataPath, WeaponStaticDataPath);
            WeaponDescriptor[] descriptors = Resources.LoadAll<WeaponDescriptor>(path);

            foreach (WeaponDescriptor descriptor in descriptors)
                _loadedWeaponDescriptorsCache.Add(descriptor.WeaponType, descriptor);

            return descriptors;
        }

        public SpaceShipDescriptor GetSpaceShipDescriptor(SpaceShipType spaceShipType)
        {
            if(_loadedSpaceShipDescriptorsCache.Count > 0)
                return _loadedSpaceShipDescriptorsCache[spaceShipType];

            return GetSpaceShipsDescriptors().FirstOrDefault(d => d.SpaceShipType == spaceShipType);
        }

        public WeaponDescriptor GetWeaponDescriptor(WeaponType weaponType)
        {
            if(_loadedWeaponDescriptorsCache.Count > 0)
                return _loadedWeaponDescriptorsCache[weaponType];

            return GetWeaponDescriptors().FirstOrDefault(d => d.WeaponType == weaponType);
        }

        public IEnumerable<ProjectileDescriptor> GetProjectileDescriptors()
        {
            if(_loadedProjectileDescriptorsCache.Count != 0)
                return _loadedProjectileDescriptorsCache.Values;

            string path = Path.Combine(StaticDataPath, ProjectileDataPath);
            ProjectileDescriptor[] descriptors = Resources.LoadAll<ProjectileDescriptor>(path);

            foreach (ProjectileDescriptor descriptor in descriptors)
                _loadedProjectileDescriptorsCache.Add(descriptor.ProjectileType, descriptor);

            return descriptors;
        }

        public ProjectileDescriptor GetProjectileDescriptor(ProjectileType projectileType)
        {
            if(_loadedProjectileDescriptorsCache.Count > 0)
                return _loadedProjectileDescriptorsCache[projectileType];

            return GetProjectileDescriptors().FirstOrDefault(d => d.ProjectileType == projectileType);
        }


    }
}