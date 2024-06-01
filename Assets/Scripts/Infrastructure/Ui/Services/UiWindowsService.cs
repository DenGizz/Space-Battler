using System;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.UI.UiElements;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Ui.Services
{
    public class UiWindowsService : IUiWindowsService
    {
        private readonly IUiAssetsProvider _uiAssetsProvider;
        private readonly IInstantiator _instantiator;
        private readonly IRootTransformsProvider _rootTransformsProvider;

        public UiWindowsService(IUiAssetsProvider uiAssetsProvider, IInstantiator instantiator, IRootTransformsProvider rootTransformsProvider)
        {
            _uiAssetsProvider = uiAssetsProvider;
            _instantiator = instantiator;
            _rootTransformsProvider = rootTransformsProvider;
        }

        public void CloseWindow(WindowPanel window)
        {
            GameObject.Destroy(window.gameObject);
        }

        public bool IsWindowOpen(WindowPanel window)
        {
            throw new NotImplementedException();
        }

        public WindowPanel OpenWindow()
        {
            GameObject windowPrefab = _uiAssetsProvider.GetWindowPrefab();
            GameObject window = _instantiator.InstantiatePrefab(windowPrefab, _rootTransformsProvider.UIRoot);
            return window.GetComponent<WindowPanel>();
        }
    }
}
