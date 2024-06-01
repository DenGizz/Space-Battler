using System.Collections.Generic;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Ui.Services;
using Assets.Scripts.UI.BattleUI;
using Assets.Scripts.UI.NewUi;
using Assets.Scripts.UI.NewUi.UiElements;
using Assets.Scripts.UI.WeaponViews;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Ui.Factories
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

        public SpaceShipTypeRowViewModel CreateSpaceShipTypeRowView()
        {
            GameObject prefab = _uiAssetsProvider.GetSpaceShipTypeRowPrefab();
            GameObject spaceShipTypeRow = _instantiator.InstantiatePrefab(prefab, _rootTransformsProvider.UIRoot);
            return spaceShipTypeRow.GetComponent<SpaceShipTypeRowViewModel>();
        }

        public UiGrid CreateUiGrid()
        {
            GameObject prefab = _uiAssetsProvider.GetUiGridPrefab();
            GameObject uiGrid = _instantiator.InstantiatePrefab(prefab, _rootTransformsProvider.UIRoot);
            return uiGrid.GetComponent<UiGrid>();
        }

        public WeaponTypeRowViewModel CreateWeaponTypeRowView()
        {
            GameObject prefab = _uiAssetsProvider.GetWeaponTypeRowPrefab();
            GameObject weaponTypeRow = _instantiator.InstantiatePrefab(prefab, _rootTransformsProvider.UIRoot);
            return weaponTypeRow.GetComponent<WeaponTypeRowViewModel>();
        }

        public WeaponTypeSlotViewModel CreateWeaponTypeSlot(Transform weaponSlotViewModelsContainer, IEnumerable<WeaponType> options)
        {
            GameObject prefab = _uiAssetsProvider.GetWeaponTypeSlotPrefab();
            GameObject weaponTypeSlot = _instantiator.InstantiatePrefab(prefab, weaponSlotViewModelsContainer);
            WeaponTypeSlotViewModel view = weaponTypeSlot.GetComponent<WeaponTypeSlotViewModel>();
            view.Options = options;
            return view;
        }
    }
}