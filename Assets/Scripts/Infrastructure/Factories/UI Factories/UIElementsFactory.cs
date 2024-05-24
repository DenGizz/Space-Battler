using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.CoreServices.AssetProviders;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.BattleUI;
using Assets.Scripts.UI.NewUi;
using Assets.Scripts.UI.NewUi.UiElements;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public class UIElementsFactory : IUiElementsFactory
    {
        private readonly IUiAssetsProvider _uiAssetsProvider;
        private readonly IInstantiator _instantiator;
        private readonly IRootTransformsProvider _rootTransformsProvider;

        [Inject]
        public UIElementsFactory(IUiAssetsProvider uiAssetsProvider, IInstantiator instantiator, IRootTransformsProvider rootTransformsProvider)
        {
            _uiAssetsProvider = uiAssetsProvider;
            _instantiator = instantiator;
            _rootTransformsProvider = rootTransformsProvider;
        }

        public HealthView CreateHealthView(ISpaceShip spaceShip, Vector2 screenPosition, Transform parent)
        {
            GameObject prefab = _uiAssetsProvider.GetSpaceShipHealthViewPrefab();
            GameObject healthView = _instantiator.InstantiatePrefab(prefab, parent);
            healthView.GetComponent<RectTransform>().position = screenPosition;
            HealthView view = healthView.GetComponent<HealthView>();
            view.SetSpaceShip(spaceShip);
            return view;
        }

        public WindowPanel CreateSpaceShipTypeSelectionWindowPanel(out UiGrid selectionGrid)
        {
            throw new System.NotImplementedException();
        }

        public UiGrid CreateUiGrid()
        {
            throw new System.NotImplementedException();
        }
    }
}