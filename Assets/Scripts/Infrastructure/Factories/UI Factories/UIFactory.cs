using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.BattleUI;
using Assets.Scripts.UI.MainMenuUI;
using Assets.Scripts.UI.Pause_Menu_UI;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public class UIFactory : IUiFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly IInstantiator _instantiator;
        private readonly IRootTransformsProvider _rootTransformsProvider;

        [Inject]
        public UIFactory(IAssetsProvider assetsProvider, IInstantiator instantiator, IRootTransformsProvider rootTransformsProvider)
        {
            _assetsProvider = assetsProvider;
            _instantiator = instantiator;
            _rootTransformsProvider = rootTransformsProvider;
        }

        public (BattleUI battleUIm, GameObject gameObject) CreateBattleUi()
        {
            GameObject battleUi = _instantiator.InstantiatePrefab(_assetsProvider.GetBattleUIPrefab(), _rootTransformsProvider.UIRoot);


            return (battleUi.GetComponentInChildren<BattleUI>(), battleUi);
        }

        public MainMenuUI CreateMainMenuUi()
        {
            GameObject mainMenuUi = _instantiator.InstantiatePrefab(_assetsProvider.GetMainMenuUIPrefab(), _rootTransformsProvider.UIRoot);

            return mainMenuUi.GetComponentInChildren<MainMenuUI>();
        }

        public BattleWinnerUI CreateWinnerUi()
        {
            GameObject winnerUi = _instantiator.InstantiatePrefab(_assetsProvider.GetWinnerUIPrefab(), _rootTransformsProvider.UIRoot);
            return winnerUi.GetComponentInChildren<BattleWinnerUI>();
        }

        public PauseResumeUI CreatePauseResumeUi()
        {
            GameObject pauseResumeUi = _instantiator.InstantiatePrefab(_assetsProvider.GetPauseResumeUIPrefab(), _rootTransformsProvider.UIRoot);
            pauseResumeUi.transform.SetAsLastSibling(); //TODO: Refactor
            return pauseResumeUi.GetComponentInChildren<PauseResumeUI>();
        }

        public DescriptionRowView CreateWeaponDescriptionRow()
        {
            GameObject descriptionRow = Object.Instantiate(_assetsProvider.GetWeaponDescriptionRowViewPrefab(), _rootTransformsProvider.UIRoot);

            return descriptionRow.GetComponentInChildren<DescriptionRowView>();
        }

        public WeaponSelectionPanelViewModel CreateWeaponSelectionPanel()
        {
            GameObject prefab = _assetsProvider.GetWeaponSelectionPanelPrefab();
            GameObject weaponSelectionPanel = _instantiator.InstantiatePrefab(prefab, _rootTransformsProvider.UIRoot);
            weaponSelectionPanel.transform.SetAsLastSibling(); //TODO: Refactor
            return weaponSelectionPanel.GetComponent<WeaponSelectionPanelViewModel>();
        }

        public SpaceShipSelectionPanelViewModel CreateSpaceShipSelectionPanel()
        {
            GameObject prefab = _assetsProvider.GetSpaceShipSelectionPanelPrefab();
            GameObject spaceShipSelectionPanel = _instantiator.InstantiatePrefab(prefab, _rootTransformsProvider.UIRoot);
            spaceShipSelectionPanel.transform.SetAsLastSibling(); //TODO: Refactor
            return spaceShipSelectionPanel.GetComponent<SpaceShipSelectionPanelViewModel>();
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
    }
}