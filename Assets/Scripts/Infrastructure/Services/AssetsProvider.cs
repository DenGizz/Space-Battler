using System.Collections;
using UnityEngine;
using System;

namespace Assets.Scripts.Infrastructure.Services
{
    public class AssetsProvider : IAssetsProvider
    {
        private GameObject _spaceShipPrefab;

        private const string PrefabsPath = "Prefabs";
        private const string SpaceShipPrefabRelativePath = "SpaceShip";

        public GameObject GetSpaceShipPrefab()
        {
            if (_spaceShipPrefab == null)
            {
                _spaceShipPrefab = LoadPrefab(System.IO.Path.Combine(PrefabsPath, SpaceShipPrefabRelativePath));
            }

            return _spaceShipPrefab;
        }


        private GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}