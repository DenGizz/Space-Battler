using System;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Ui.Services;
using Assets.Scripts.UI.OverlayScreens;
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

        public ChangeLanguageUiScreenOverlay CreateChangeLanguageUiScreenOverlay()
        {
            GameObject prefab = _uiAssetsProvider.GetChangeLanguageUiScreenOverlayPrefab();
            Transform parentTransform = _rootTransformsProvider.UIRoot;
            GameObject instance = _instantiator.InstantiatePrefab(prefab, parentTransform);
            instance.transform.SetAsLastSibling();
            GameObject.DontDestroyOnLoad(instance);
            ChangeLanguageUiScreenOverlay overlay = instance.GetComponent<ChangeLanguageUiScreenOverlay>();
            return overlay;
        }

        public UiScreenOverlay CreateLoadingOverlay()
        {
            throw new NotImplementedException();
        }

        public UI.Uis.Ui CreateMainMenuUi()
        {
            GameObject prefab = _uiAssetsProvider.GetMainMenuUiPrefab();
            return InstantiateAndInitializeUiFromPrefab(prefab);
        }

        public PopoutMessagesUiScreenOverlay CreatePopoutMessagesOverlay()
        {
            GameObject prefab = _uiAssetsProvider.GetPopoutMessagesOverlayPrefab();
            Transform parentTransform = _rootTransformsProvider.UIRoot;
            GameObject instance = _instantiator.InstantiatePrefab(prefab, parentTransform);
            instance.transform.SetAsLastSibling();
            GameObject.DontDestroyOnLoad(instance);
            PopoutMessagesUiScreenOverlay popoutMessagesUiScreenOverlay = instance.GetComponent<PopoutMessagesUiScreenOverlay>();
            return popoutMessagesUiScreenOverlay;
        }

        public UI.Uis.Ui CreateSandboxBattleUi()
        {
            GameObject prefab = _uiAssetsProvider.GetSandboxModeUiPrefab();
            return InstantiateAndInitializeUiFromPrefab(prefab);
        }

        private UI.Uis.Ui InstantiateAndInitializeUiFromPrefab(GameObject prefab)
        {
            Transform patentTransform = _rootTransformsProvider.UIRoot;
            GameObject instance = _instantiator.InstantiatePrefab(prefab, patentTransform);
            UI.Uis.Ui ui = instance.GetComponent<UI.Uis.Ui>() ?? throw new Exception("Ui prefab does not contain Ui component"); //TODO: Create custom exception
            ui.Initialize();
            return ui;
        }
    }
}
