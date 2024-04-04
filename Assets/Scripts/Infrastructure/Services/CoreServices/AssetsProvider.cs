using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts.Weapons.WeaponConfigs;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class AssetsProvider : IAssetsProvider
    {
        private GameObject _spaceShipPrefab;
        private GameObject _battleUIPrefab;
        private GameObject _mainMenuUIPrefab;

        private readonly Dictionary<WeaponType, GameObject> _weaponPrefabs;
        private readonly Dictionary<WeaponType, string> _weaponPrefabNames;

        private const string PrefabsPathRoot = "Prefabs";
        private const string SpaceShipPrefabRelativePath = "Space Ship";

        private const string UIPathRoot = "UI";
        private const string BattleUIPrefabRelativePath = "Battle UI";
        private const string MainMenuUIPrefabRelativePath = "Main Menu UI";

        private const string StaticDataPathRoot = "StaticData";
        private const string SpaceShipConfigSOPath = "SpaceShipConfigs";
        private const string WeaponConfigSOPath = "WeaponConfigs";

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
        }

        public GameObject GetSpaceShipPrefab()
        {
            if (_spaceShipPrefab == null)
            {
                _spaceShipPrefab = LoadPrefab(System.IO.Path.Combine(PrefabsPathRoot, SpaceShipPrefabRelativePath));
            }

            return _spaceShipPrefab;
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

        public GameObject GetWeaponPrefab(WeaponType weaponType)
        {
            if (!_weaponPrefabs.ContainsKey(weaponType))
            {
                string weaponPrefabName = _weaponPrefabNames[weaponType];
                GameObject weaponPrefab = LoadPrefab(Path.Combine(PrefabsPathRoot, weaponPrefabName));
                _weaponPrefabs.Add(weaponType, weaponPrefab);
            }

            return _weaponPrefabs[weaponType];
        }

        public IEnumerable<SpaceShipConfigSO> GetSpaceShipConfigurationSOs()
        {
            return LoadStaticDataScriptableObjects<SpaceShipConfigSO>(SpaceShipConfigSOPath);
        }

        public IEnumerable<WeaponConfigSO> GetWeaponConfigurationSOs()
        {      
            return LoadStaticDataScriptableObjects<WeaponConfigSO>(WeaponConfigSOPath);
        }

        private IEnumerable<T> LoadStaticDataScriptableObjects<T>(string relativePath) where T : ScriptableObject
        {
            return Resources.LoadAll<T>(Path.Combine(StaticDataPathRoot, relativePath));
        }

        private GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}