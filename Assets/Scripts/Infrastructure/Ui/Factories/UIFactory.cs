using System;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Ui.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Ui.Factories
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

        public global::Assets.Scripts.UI.Uis.Ui CreateMainMenuUi()
        {
            GameObject prefab = _uiAssetsProvider.GetMainMenuUiPrefab();
            return InstantiateAndInitializeUiFromPrefab(prefab);
        }

        public global::Assets.Scripts.UI.Uis.Ui CreateSandboxBattleUi()
        {
            GameObject prefab = _uiAssetsProvider.GetSandboxModeUiPrefab();
            return InstantiateAndInitializeUiFromPrefab(prefab);
        }

        private global::Assets.Scripts.UI.Uis.Ui InstantiateAndInitializeUiFromPrefab(GameObject prefab)
        {
            Transform patentTransform = _rootTransformsProvider.UIRoot;
            GameObject instance = _instantiator.InstantiatePrefab(prefab, patentTransform);
            global::Assets.Scripts.UI.Uis.Ui ui = instance.GetComponent<global::Assets.Scripts.UI.Uis.Ui>() ?? throw new Exception("Ui prefab does not contain Ui component"); //TODO: Create custom exception
            ui.Initialize();
            return ui;
        }
    }
}
