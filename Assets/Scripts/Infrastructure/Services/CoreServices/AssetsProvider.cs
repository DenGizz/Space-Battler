using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts.Weapons.WeaponConfigs;
using System.Linq;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Unity.VisualScripting;
using UnityEditor;
using Assets.Scripts.Infrastructure.Config;
using Assets.Scripts.Projectiles;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class AssetsProvider : IAssetsProvider
    {
        private const string BandlesPath = "Bandles";
        private const string UiPrefabsBanldeAssetName = "UiPrefabsBanle";
        private const string StaticDataPath = "StaticData";
        private const string SpaceShipsStaticDataPath = "SpaceShipDescriptors";
        private const string WeaponStaticDataPath = "WeaponDescriptors";
        private const string ProjectileDataPath = "ProjectileDescriptors";

        private readonly Dictionary<SpaceShipType, SpaceShipDescriptor> _loadedSpaceShipDescriptorsCache;
        private readonly Dictionary<WeaponType, WeaponDescriptor> _loadedWeaponDescriptorsCache;
        private readonly Dictionary<ProjectileType, ProjectileDescriptor> _loadedProjectileDescriptorsCache;

        private  UiPrefabsBanlde _uiPrefabsBandleCache;

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

        public GameObject GetBattleUIPrefab()
        {
            return GetOrLoadAndCacheUiPrefabsBanlde().BattleUIPrefab;
        }

        public GameObject GetMainMenuUIPrefab()
        {
            return GetOrLoadAndCacheUiPrefabsBanlde().MainMenuUIPrefab;
        }

        public GameObject GetPauseResumeUIPrefab()
        {
            return GetOrLoadAndCacheUiPrefabsBanlde().PauseResumeUIPrefab;
        }

        public GameObject GetWeaponDescriptionRowViewPrefab()
        {
            return GetOrLoadAndCacheUiPrefabsBanlde().WeaponDescriptionRowViewPrefab;
        }

        public GameObject GetWeaponSelectionPanelPrefab()
        {
            return GetOrLoadAndCacheUiPrefabsBanlde().WeaponSelectionPanelPrefab;
        }

        public GameObject GetSpaceShipSelectionPanelPrefab()
        {
            return GetOrLoadAndCacheUiPrefabsBanlde().SpaceShipSelectionPanelPrefab;
        }

        public GameObject GetSpaceShipDescriptionRowViewPrefab()
        {
            return GetOrLoadAndCacheUiPrefabsBanlde().SpaceShipDescriptionRowViewPrefab;
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

        private UiPrefabsBanlde GetOrLoadAndCacheUiPrefabsBanlde()
        {
            if(_uiPrefabsBandleCache != null)
                return _uiPrefabsBandleCache;

            _uiPrefabsBandleCache = Resources.Load<UiPrefabsBanlde>(Path.Combine(BandlesPath,UiPrefabsBanldeAssetName));
            return _uiPrefabsBandleCache;
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