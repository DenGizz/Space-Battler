﻿using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class AssetsProvider : IAssetsProvider
    {
        private GameObject _spaceShipPrefab;
        private GameObject _battleUIPrefab;
        private GameObject _mainMenuUIPrefab;

        private const string PrefabsPathRoot = "Prefabs";
        private const string SpaceShipPrefabRelativePath = "Space Ship";

        private const string UIPathRoot = "UI";
        private const string BattleUIPrefabRelativePath = "Battle UI";
        private const string MainMenuUIPrefabRelativePath = "Main Menu UI";

        private const string StaticDataPathRoot = "StaticData";
        private const string SpaceShipConfigSOPath = "SpaceShipConfigs";

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

        public IEnumerable<SpaceShipConfigSO> GetSpaceShipConfigurationSOs()
        {
            return Resources.LoadAll<SpaceShipConfigSO>(Path.Combine(StaticDataPathRoot, SpaceShipConfigSOPath));
        }

        private GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}