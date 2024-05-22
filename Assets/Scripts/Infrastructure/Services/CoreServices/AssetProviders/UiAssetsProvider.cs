using Assets.Scripts.ScriptableObjects.ResourceBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices.AssetProviders
{
    public class UiAssetsProvider : IUiAssetsProvider
    {
        private const string BundlesFolderPath = "Bundles";

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

        private UiResourcesBundle GetOrLoadAndGetUiResourcesBundle()
        {
            if (_uiResourcesBundle == null)
                _uiResourcesBundle = Resources.Load<UiResourcesBundle>(BundlesFolderPath);

            return _uiResourcesBundle;
        }

        private UiElementPrefabsBundle GetOrLoadAndGetUiElementPrefabsBundle()
        {
            if (_uiElementPrefabsBundle == null)
                _uiElementPrefabsBundle = Resources.Load<UiElementPrefabsBundle>(BundlesFolderPath);

            return _uiElementPrefabsBundle;
        }
    }
}
