using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.CoreServices.AssetProviders;
using Assets.Scripts.UI.NewUi.UiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.UiInfrastructure
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
