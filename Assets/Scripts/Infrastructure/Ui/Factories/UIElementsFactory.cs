using System.Collections.Generic;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Ui.Services;
using Assets.Scripts.UI.PopoutMessages;
using Assets.Scripts.UI.UiElements;
using Assets.Scripts.UI.ViewModels;
using Assets.Scripts.UI.ViewModels.SlotViewModels;
using Assets.Scripts.UI.ViewModels.SpaceShipSetupEditor;
using Assets.Scripts.UI.ViewModels.SpaceShipViewModels;
using Assets.Scripts.UI.ViewModels.WeaponViewModels;
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

        public PopoutMessageViewModel CreatePopoutMessage()
        {
            GameObject prefab = _uiAssetsProvider.GetPopoutMessagePrefab();
            GameObject popoutMessage = _instantiator.InstantiatePrefab(prefab, _rootTransformsProvider.UIRoot);
            return popoutMessage.GetComponent<PopoutMessageViewModel>();
        }

        public SpaceShipSetupEditViewModel CreateSpaceShipSetupEditView()
        {
            GameObject prefab = _uiAssetsProvider.GetSpaceShipSetupEditPrefab();
            GameObject spaceShipSetupEdit = _instantiator.InstantiatePrefab(prefab, _rootTransformsProvider.UIRoot);
            return spaceShipSetupEdit.GetComponent<SpaceShipSetupEditViewModel>();
        }

        public SpaceShipSetupViewModel CreateSpaceShipSetupRowView()
        {
            GameObject prefab = _uiAssetsProvider.GetSpaceShipSetupRowPrefab();
            GameObject spaceShipSetupRow = _instantiator.InstantiatePrefab(prefab, _rootTransformsProvider.UIRoot);
            return spaceShipSetupRow.GetComponent<SpaceShipSetupViewModel>();
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

        public WeaponTypeSlotViewModel CreateWeaponTypeSlot(Transform weaponSlotViewModelsContainer, IEnumerable<WeaponType> options, WeaponType defaultOption, WeaponType selectedOption)
        {
            GameObject prefab = _uiAssetsProvider.GetWeaponTypeSlotPrefab();
            GameObject weaponTypeSlot = _instantiator.InstantiatePrefab(prefab, weaponSlotViewModelsContainer);
            WeaponTypeSlotViewModel view = weaponTypeSlot.GetComponent<WeaponTypeSlotViewModel>();
            view.SetOptions(options, defaultOption, selectedOption);
            return view;
        }
    }
}