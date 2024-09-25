using System;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.UI.UiElements;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Ui.Services
{
    public class UiWindowsService : IUiWindowsService
    {
        private readonly IUiAssetsProvider _uiAssetsProvider;
        private readonly IInstantiator _instantiator;
        private readonly IRootTransformsProvider _rootTransformsProvider;

        private readonly List<UiWindow> _openedWindows;

        public UiWindowsService(IUiAssetsProvider uiAssetsProvider, IInstantiator instantiator, IRootTransformsProvider rootTransformsProvider)
        {
            _uiAssetsProvider = uiAssetsProvider;
            _instantiator = instantiator;
            _rootTransformsProvider = rootTransformsProvider;

            _openedWindows = new List<UiWindow>();
        }

        public void CloseAllWindows()
        {
            _openedWindows.ForEach(window => GameObject.Destroy(window.gameObject));
            _openedWindows.Clear();
        }

        public void CloseWindow(UiWindow uiWindow)
        {
            _openedWindows.Remove(uiWindow);
            GameObject.Destroy(uiWindow.gameObject);
        }

        public bool IsWindowOpen(UiWindow uiWindow)
        {
            throw new NotImplementedException();
        }

        public UiWindow OpenWindow()
        {
            GameObject windowPrefab = _uiAssetsProvider.GetWindowPrefab();
            GameObject windowGameObject = _instantiator.InstantiatePrefab(windowPrefab, _rootTransformsProvider.UIRoot);

            UiWindow UiWindow = windowGameObject.GetComponent<UiWindow>();

            _openedWindows.Add(UiWindow);

            return UiWindow;
        }
    }
}
