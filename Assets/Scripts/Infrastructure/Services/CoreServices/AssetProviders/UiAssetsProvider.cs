using Assets.Scripts.ScriptableObjects.ResourceBundles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices.AssetProviders
{
    public class UiAssetsProvider : IUiAssetsProvider
    {
        private const string BundlesFolderPath = "Bundles";
        private const string UiResourcesBundleName = "UiResourcesBundle";
        private const string UiElementPrefabsBundleName = "UiElementPrefabsBundle";

        private UiResourcesBundle _uiResourcesBundle;
        private UiElementPrefabsBundle _uiElementPrefabsBundle;

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
    }
}
