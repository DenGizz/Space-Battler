using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using Assets.Scripts.Weapons.WeaponConfigs;

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
        private const string BattleUIPrefabRelativePath = "Battle UI";
        private const string MainMenuUIPrefabRelativePath = "Main Menu UI";

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



        private GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}