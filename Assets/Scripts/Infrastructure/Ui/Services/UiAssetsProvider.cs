using System;
using System.IO;
using Assets.Scripts.ScriptableObjects.ResourceBundles;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Ui.Services
{
    public class UiAssetsProvider : IUiAssetsProvider
    {
        private const string BundlesFolderPath = "Bundles";
        private const string UiResourcesBundleName = "UiResourcesBundle";
        private const string UiElementPrefabsBundleName = "UiElementPrefabsBundle";
        private const string HUDPrefabsBundleName = "HUDPrefabsBundle";

        private UiResourcesBundle _uiResourcesBundle;
        private UiElementPrefabsBundle _uiElementPrefabsBundle;
        private HUDPrefabsBundle _hudPrefabsBundle;

        public GameObject GetMainMenuUiPrefab()
        {
            return GetOrLoadAndGetUiResourcesBundle().MainMenuUiPrefab;
        }

        public GameObject GetSandboxModeUiPrefab()
        {
            return GetOrLoadAndGetUiResourcesBundle().SandboxModeUiPrefab;
        }

        public GameObject GetSpaceShipHealthViewPrefab()
        {
            return GetOrLoadAndGetUiElementPrefabsBundle().SpaceShipHealthViewPrefab;
        }

        public GameObject GetWindowPrefab()
        {
            return GetOrLoadAndGetUiElementPrefabsBundle().WindowPrefab;
        }

        public GameObject GetWeaponTypeSlotPrefab()
        {
            return GetOrLoadAndGetUiElementPrefabsBundle().WeaponTypeSlotPrefab;
        }

        public GameObject GetUiGridPrefab()
        {
            return GetOrLoadAndGetUiElementPrefabsBundle().UiGridPrefab;
        }

        private UiResourcesBundle GetOrLoadAndGetUiResourcesBundle()
        {
            if (_uiResourcesBundle == null)
                _uiResourcesBundle = LoadBundle<UiResourcesBundle>(UiResourcesBundleName);

            return _uiResourcesBundle;
        }

        private UiElementPrefabsBundle GetOrLoadAndGetUiElementPrefabsBundle()
        {
            if (_uiElementPrefabsBundle == null)
                _uiElementPrefabsBundle = LoadBundle<UiElementPrefabsBundle>(UiElementPrefabsBundleName);

            return _uiElementPrefabsBundle;
        }

        private HUDPrefabsBundle GetOrLoadAndGetHudPrefabsBundle()
        {
            if (_hudPrefabsBundle == null)
                _hudPrefabsBundle = LoadBundle<HUDPrefabsBundle>(HUDPrefabsBundleName);

            return _hudPrefabsBundle;
        }

        private T LoadBundle<T>(string bundleName) where T : UnityEngine.Object
        {
            string bundlePath = Path.Combine(BundlesFolderPath, bundleName);
            return Resources.Load<T>(bundlePath) ??
                throw new NullReferenceException($"Bundle not found at {bundlePath}");
        }

        public GameObject GetWeaponTypeRowPrefab()
        {
            return GetOrLoadAndGetUiElementPrefabsBundle().WeaponTypeRowPrefab;
        }

        public GameObject GetSpaceShipTypeRowPrefab()
        {
            return GetOrLoadAndGetUiElementPrefabsBundle().SpaceShipTypeRowPrefab;
        }

        public GameObject GetPauseBattleHUDPrefab()
        {
            return GetOrLoadAndGetHudPrefabsBundle().PauseBattleHUDPrefab;
        }
    }
}
