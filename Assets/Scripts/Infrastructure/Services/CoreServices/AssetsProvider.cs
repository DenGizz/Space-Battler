using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts.Weapons.WeaponConfigs;
using System.Linq;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Unity.VisualScripting;
using UnityEditor;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class AssetsProvider : IAssetsProvider
    {
        private const string PrefabsPath = "Prefabs";

        private const string UIPrefabsPath = "UI";
        private const string BattleUIPrefabsPath = "Battle UI";
        private const string MainMenuUIPrefabsPath = "Main Menu UI";
        private const string SpaceShipSetupUIPrefabsPath = "Space Ship Setup UI";
        private const string WeaponDescriptionRowViewPrefabName = "Weapon Description Row View";
        private const string WeaponSelectionPanelPrefabName = "Weapon Selection Panel";
        private const string SlotForSelectWeaponViewPrefabName = "Slot For Select Weapon View";
        private const string SpaceShipSelectionPanelPrefabName = "Space Ship Selection Panel";
        private const string SpaceShipDescriptionRowViewPrefabName = "Space Ship Description Row View";

        private const string SpaceShipPrefabsPath = "SpaceShips";
        private readonly Dictionary<SpaceShipType, string> _spaceShipPrefabNames = new Dictionary<SpaceShipType, string>
        {
                {SpaceShipType.HeavyDefender, "HeavyDefender"},
                {SpaceShipType.LiteAttacker, "LiteAttacker"}
        };

        private const string WeaponPrefabsPath = "Weapons";
        private readonly Dictionary<WeaponType, string> _weaponPrefabNames = new Dictionary<WeaponType, string>
        {
                {WeaponType.HeavyMachineGun, "HeavyMachineGun"},
                {WeaponType.GrenadeLauncher, "GrenadeLauncher"},
                {WeaponType.RocketLauncher, "RockerLauncher"},
                {WeaponType.LiteBlaster, "LiteBlaster"}
        };

        private const string StaticDataPath = "StaticData";
        private const string SpaceShipsStaticDataPath = "SpaceShipDescriptors";
        private const string WeaponStaticDataPath = "WeaponDescriptors";

        private readonly Dictionary<SpaceShipType, SpaceShipDescriptor> _loadedSpaceShipDescriptorsCache;
        private readonly Dictionary<WeaponType, WeaponDescriptor> _loadedWeaponDescriptorsCache;

        public AssetsProvider()
        {
            _loadedSpaceShipDescriptorsCache = new Dictionary<SpaceShipType, SpaceShipDescriptor>();
            _loadedWeaponDescriptorsCache = new Dictionary<WeaponType, WeaponDescriptor>();
        }

        public GameObject GetSpaceShipPrefab(SpaceShipType spaceShipType)
        {
            string path = Path.Combine(PrefabsPath, SpaceShipPrefabsPath, _spaceShipPrefabNames[spaceShipType]);
            return Resources.Load<GameObject>(path);
        }

        public GameObject GetWeaponPrefab(WeaponType weaponType)
        {
            string path = Path.Combine(PrefabsPath, WeaponPrefabsPath, _weaponPrefabNames[weaponType]);
            return Resources.Load<GameObject>(path);
        }

        public GameObject GetBattleUIPrefab()
        {
            string path = Path.Combine(PrefabsPath, UIPrefabsPath, BattleUIPrefabsPath);
            return Resources.Load<GameObject>(path);
        }

        public GameObject GetMainMenuUIPrefab()
        {
            string path = Path.Combine(PrefabsPath, UIPrefabsPath, MainMenuUIPrefabsPath);
            return Resources.Load<GameObject>(path);
        }

        public GameObject GetWeaponDescriptionRowViewPrefab()
        {
            string path = Path.Combine(PrefabsPath, UIPrefabsPath, SpaceShipSetupUIPrefabsPath, WeaponDescriptionRowViewPrefabName);
            return Resources.Load<GameObject>(path);
        }

        public GameObject GetWeaponSelectionPanelPrefab()
        {
            string path = Path.Combine(PrefabsPath, UIPrefabsPath, SpaceShipSetupUIPrefabsPath, WeaponSelectionPanelPrefabName);
            return Resources.Load<GameObject>(path);
        }

        public GameObject GetSlotForSelectWeaponPrefab()
        {
            string path = Path.Combine(PrefabsPath, UIPrefabsPath, SpaceShipSetupUIPrefabsPath, SlotForSelectWeaponViewPrefabName);
            return Resources.Load<GameObject>(path);
        }

        public GameObject GetSpaceShipSelectionPanelPrefab()
        {
            string path = Path.Combine(PrefabsPath, UIPrefabsPath, SpaceShipSetupUIPrefabsPath, SpaceShipSelectionPanelPrefabName);
            return Resources.Load<GameObject>(path);
        }

        public GameObject GetSpaceShipDescriptionRowViewPrefab()
        {
            string path = Path.Combine(PrefabsPath, UIPrefabsPath, SpaceShipSetupUIPrefabsPath, SpaceShipDescriptionRowViewPrefabName);
            return Resources.Load<GameObject>(path);
        }

        public IEnumerable<SpaceShipDescriptor> GetSpaceShipsConfigs()
        {
            if(_loadedSpaceShipDescriptorsCache.Count != 0)
                return _loadedSpaceShipDescriptorsCache.Values;

            string path = Path.Combine(StaticDataPath, SpaceShipsStaticDataPath);
            SpaceShipDescriptor[] descriptors = Resources.LoadAll<SpaceShipDescriptor>(path);

            foreach (SpaceShipDescriptor descriptor in descriptors)
                _loadedSpaceShipDescriptorsCache.Add(descriptor.CorpusType, descriptor);

            return descriptors;
        }

        public IEnumerable<WeaponDescriptor> GetWeaponConfigs()
        {
            if(_loadedWeaponDescriptorsCache.Count != 0)
                return _loadedWeaponDescriptorsCache.Values;

            string path = Path.Combine(StaticDataPath, WeaponStaticDataPath);
            WeaponDescriptor[] descriptors = Resources.LoadAll<WeaponDescriptor>(path);

            foreach (WeaponDescriptor descriptor in descriptors)
                _loadedWeaponDescriptorsCache.Add(descriptor.WeaponType, descriptor);

            return descriptors;
        }

        public SpaceShipDescriptor GetSpaceShipConfig(SpaceShipType spaceShipType)
        {
            if(_loadedSpaceShipDescriptorsCache.Count > 0)
                return _loadedSpaceShipDescriptorsCache[spaceShipType];

            return GetSpaceShipsConfigs().FirstOrDefault(d => d.CorpusType == spaceShipType);
        }

        public WeaponDescriptor GetWeaponConfig(WeaponType weaponType)
        {
            if(_loadedWeaponDescriptorsCache.Count > 0)
                return _loadedWeaponDescriptorsCache[weaponType];

            return GetWeaponConfigs().FirstOrDefault(d => d.WeaponType == weaponType);
        }
    }
}