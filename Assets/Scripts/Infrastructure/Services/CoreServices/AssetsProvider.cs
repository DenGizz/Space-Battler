using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts.Weapons.WeaponConfigs;
using System.Linq;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class AssetsProvider : IAssetsProvider
    {
        private GameObject _battleUIPrefab;
        private GameObject _mainMenuUIPrefab;

        private readonly Dictionary<SpaceShipType, GameObject> _spaceShipPrefabs;
        private readonly Dictionary<SpaceShipType, string> _spaceShipPrefabNames;

        private readonly Dictionary<WeaponType, GameObject> _weaponPrefabs;
        private readonly Dictionary<WeaponType, string> _weaponPrefabNames;

        private const string PrefabsPathRoot = "Prefabs";
        private const string WeaponPrefabs = "Weapons";
        private const string SpaceShipPrefabs = "SpaceShips";

        private const string UIPathRoot = "UI";
        private const string BaseUI = "Base UI";
        private const string BattleUIPrefabRelativePath = "Battle UI";
        private const string MainMenuUIPrefabRelativePath = "Main Menu UI";

        public AssetsProvider()
        {
            _weaponPrefabs = new Dictionary<WeaponType, GameObject>();
            //TODO: refactor this to use WeaponConfigSO
            _weaponPrefabNames = new Dictionary<WeaponType, string>
            {
                { WeaponType.HeavyMachineGun, "HeavyMachineGun" },
                { WeaponType.GrenadeLauncher, "GrenadeLauncher" },
                { WeaponType.RocketLauncher, "RockerLauncher" },
                { WeaponType.LiteBlaster, "LiteBlaster" },
            };

            _spaceShipPrefabs = new Dictionary<SpaceShipType, GameObject>();

            _spaceShipPrefabNames = new Dictionary<SpaceShipType, string>()
            {
                {SpaceShipType.HeavyDefender, "HeavyDefender"},
                {SpaceShipType.LiteAttacker, "LiteAttacker"}
            };
        }

        public GameObject GetSpaceShipPrefab(SpaceShipType spaceShipType)
        {
            if (_spaceShipPrefabs.ContainsKey(spaceShipType))
                return _spaceShipPrefabs[spaceShipType];

            string spaceShipPrefabName = _spaceShipPrefabNames[spaceShipType];
            GameObject weaponPrefab = LoadPrefab(Path.Combine(PrefabsPathRoot, SpaceShipPrefabs, spaceShipPrefabName));
            _spaceShipPrefabs.Add(spaceShipType, weaponPrefab);

            return _spaceShipPrefabs[spaceShipType];
        }

        public GameObject GetWeaponPrefab(WeaponType weaponType)
        {
            if (_weaponPrefabs.ContainsKey(weaponType))
                return _weaponPrefabs[weaponType];

            string weaponPrefabName = _weaponPrefabNames[weaponType];
            GameObject weaponPrefab = LoadPrefab(Path.Combine(PrefabsPathRoot, WeaponPrefabs, weaponPrefabName));
            _weaponPrefabs.Add(weaponType, weaponPrefab);

            return _weaponPrefabs[weaponType];
        }


        public GameObject GetBattleUIPrefab()
        {
            if (_battleUIPrefab == null)
            {
                _battleUIPrefab = LoadPrefab(System.IO.Path.Combine(PrefabsPathRoot, UIPathRoot, BattleUIPrefabRelativePath));
            }

            return _battleUIPrefab;
        }

        public GameObject GetMainMenuUIPrefab()
        {
            if (_mainMenuUIPrefab == null)
            {
                _mainMenuUIPrefab = LoadPrefab(Path.Combine(PrefabsPathRoot, UIPathRoot, MainMenuUIPrefabRelativePath));
            }

            return _mainMenuUIPrefab;
        }

        public GameObject GetWeaponDescriptionRowViewPrefab()
        {
            return Resources.Load<GameObject>(Path.Combine(PrefabsPathRoot, UIPathRoot,"Space Ship Setup UI", "Weapon Description Row View"));
        }

        public GameObject GetWeaponSelectionPanelPrefab()
        {
            return Resources.Load<GameObject>(Path.Combine(PrefabsPathRoot, UIPathRoot,
                "Space Ship Setup UI", "Weapon Selection Panel"));
        }

        public GameObject GetSlotForSelectWeaponPrefab()
        {
            return Resources.Load<GameObject>(Path.Combine(PrefabsPathRoot, UIPathRoot,
                "Space Ship Setup UI", "Slot For Select Weapon View"));
        }

        public SpaceShipConfigSO GetSpaceShipConfig(SpaceShipType spaceShipType)
        {
            var sgos = Resources.LoadAll<SpaceShipConfigSO>(Path.Combine("StaticData","SpaceShipConfigs"));
            return sgos.FirstOrDefault(sgo => sgo.CorpusType == spaceShipType);
        }

        public WeaponConfigSO GetWeaponConfig(WeaponType weaponType)
        {
            var sgos = Resources.LoadAll<WeaponConfigSO>(Path.Combine("StaticData", "WeaponConfigs"));
            return sgos.FirstOrDefault(sgo => sgo.WeaponType == weaponType);
        }

        public IEnumerable<WeaponConfigSO> GetWeaponConfigs()
        {
            return Resources.LoadAll<WeaponConfigSO>(Path.Combine("StaticData", "WeaponConfigs"));
        }

        private GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }

        public GameObject GetSpaceShipSelectionPanelPrefab()
        {
            return Resources.Load<GameObject>(Path.Combine(PrefabsPathRoot, UIPathRoot, "Space Ship Setup UI", "Space Ship Selection Panel"));
        }

        public GameObject GetSpaceShipDescriptionRowViewPrefab()
        {
            return Resources.Load<GameObject>(Path.Combine(PrefabsPathRoot, UIPathRoot, "Space Ship Setup UI", "Space Ship Description Row View"));
        }

        public IEnumerable<SpaceShipConfigSO> GetSpaceShipsConfigs()
        {
            return Resources.LoadAll<SpaceShipConfigSO>(Path.Combine("StaticData", "SpaceShipConfigs"));
        }
    }
}