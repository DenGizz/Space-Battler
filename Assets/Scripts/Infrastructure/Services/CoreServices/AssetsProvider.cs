using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class AssetsProvider : IAssetsProvider
    {
        private GameObject _spaceShipPrefab;
        private GameObject _battleUIPrefab;

        private const string PrefabsPathRoot = "Prefabs";
        private const string SpaceShipPrefabRelativePath = "Space Ship";

        private const string UIPathRoot = "UI";
        private const string BattleUIPrefabRelativePath = "Battle UI";

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


        private GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}