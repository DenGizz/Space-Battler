using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Services.CoreServices;
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
        private readonly IAssetsProvider _assetsProvider;
        private readonly IInstantiator _instantiator;
        private readonly IRootTransformsProvider _rootTransformsProvider;

        [Inject]
        public UIElementsFactory(IAssetsProvider assetsProvider, IInstantiator instantiator, IRootTransformsProvider rootTransformsProvider)
        {
            _assetsProvider = assetsProvider;
            _instantiator = instantiator;
            _rootTransformsProvider = rootTransformsProvider;
        }

        public BattleWinnerViewModel CreateWinnerUi()
        {
            GameObject winnerUi = _instantiator.InstantiatePrefab(_assetsProvider.GetWinnerUIPrefab(), _rootTransformsProvider.UIRoot);
            return winnerUi.GetComponentInChildren<BattleWinnerViewModel>();
        }


        public DescriptionRowView CreateWeaponDescriptionRow()
        {
            GameObject descriptionRow = Object.Instantiate(_assetsProvider.GetWeaponDescriptionRowViewPrefab(), _rootTransformsProvider.UIRoot);

            return descriptionRow.GetComponentInChildren<DescriptionRowView>();
        }

        public DescriptionRowView CreateSpaceShipDescriptionRow()
        {
            GameObject descriptionRow = Object.Instantiate(_assetsProvider.GetSpaceShipDescriptionRowViewPrefab(), _rootTransformsProvider.UIRoot);

            return descriptionRow.GetComponentInChildren<DescriptionRowView>();
        }

        public HealthView CreateHealthView(ISpaceShip spaceShip, Vector2 screenPosition, Transform parent)
        {
            //TODO: Use IAssetsProvider
            GameObject prefab = Resources.Load<GameObject>("Prefabs/UI/Battle UI/Space Ship Health View");
            GameObject healthView = _instantiator.InstantiatePrefab(prefab, parent);
            healthView.GetComponent<RectTransform>().position = screenPosition;
            HealthView view = healthView.GetComponent<HealthView>();
            view.SetSpaceShip(spaceShip);
            return view;
        }

        public WindowPanel CreateWeaponSelectionWindowPanel(out SelectionGrid selectionGrid)
        {
            throw new System.NotImplementedException();
        }

        public WeaponTypeSlotViewModel CreateWeaponTypeSlot(Transform weaponSlotViewModelsContainer)
        {
            throw new System.NotImplementedException();
        }
    }
}