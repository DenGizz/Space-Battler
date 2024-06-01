using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.CoreServices.AssetProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public class UiFactory : IUiFactory
    {
        private readonly IUiAssetsProvider _uiAssetsProvider;
        private readonly IInstantiator _instantiator;
        private readonly IRootTransformsProvider _rootTransformsProvider;

        public UiFactory(IUiAssetsProvider uiAssetsProvider, IInstantiator instantiator, IRootTransformsProvider rootTransformsProvider)
        {
            _uiAssetsProvider = uiAssetsProvider;
            _instantiator = instantiator;
            _rootTransformsProvider = rootTransformsProvider;
        }

        public Ui CreateMainMenuUi()
        {
            GameObject prefab = _uiAssetsProvider.GetMainMenuUiPrefab();
            return InstantiateAndInitializeUiFromPrefab(prefab);
        }

        public Ui CreateSandboxBattleUi()
        {
            GameObject prefab = _uiAssetsProvider.GetSandboxModeUiPrefab();
            return InstantiateAndInitializeUiFromPrefab(prefab);
        }

        private Ui InstantiateAndInitializeUiFromPrefab(GameObject prefab)
        {
            Transform patentTransform = _rootTransformsProvider.UIRoot;
            GameObject instance = _instantiator.InstantiatePrefab(prefab, patentTransform);
            Ui ui = instance.GetComponent<Ui>() ?? throw new Exception("Ui prefab does not contain Ui component"); //TODO: Create custom exception
            ui.Initialize();
            return ui;
        }
    }
}
