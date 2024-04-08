using System.Collections;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.UI;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.WeaponSelectionUI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public class UIFactory : IUIFactory
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

        public (BattleUI battleUIm, GameObject gameObject) CreateBattleUI()
        {
            GameObject battleUI = GameObject.Instantiate(_assetsProvider.GetBattleUIPrefab(), _rootTransformsProvider.UIRoot);

            return (battleUI.GetComponentInChildren<BattleUI>(), battleUI);
        }

        public MainMenuUI CreateMainMenuUI()
        {
            GameObject mainMenuUI = _instantiator.InstantiatePrefab(_assetsProvider.GetMainMenuUIPrefab(), _rootTransformsProvider.UIRoot);

            return mainMenuUI.GetComponentInChildren<MainMenuUI>();
        }

        public PauseResumeUI CreatePauseResumeUi()
        {
            GameObject pauseResumeUI = _instantiator.InstantiatePrefab(_assetsProvider.GetPauseResumeUIPrefab(), _rootTransformsProvider.UIRoot);
            pauseResumeUI.transform.SetAsLastSibling(); //TODO: Refactor
            return pauseResumeUI.GetComponentInChildren<PauseResumeUI>();
        }

        public DescriptionRowView CreateWeaponDescriptionRowView()
        {
            GameObject descriptionRow = GameObject.Instantiate(_assetsProvider.GetWeaponDescriptionRowViewPrefab(), _rootTransformsProvider.UIRoot);

            return descriptionRow.GetComponentInChildren<DescriptionRowView>();
        }

        public WeaponSelectionPanelViewModel CreateWeaponSelectionPanelViewPanel()
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

        public SlotForSelectWeaponViewModel CreateSlotForSelectWeaponViewPanel()
        {
            GameObject prefab = _assetsProvider.GetSlotForSelectWeaponPrefab();
            GameObject go = _instantiator.InstantiatePrefab(prefab, _rootTransformsProvider.UIRoot);

            return go.GetComponent<SlotForSelectWeaponViewModel>();
        }

        public DescriptionRowView CreateSpaceShipDescriptionRowView()
        {
            GameObject descriptionRow = GameObject.Instantiate(_assetsProvider.GetSpaceShipDescriptionRowViewPrefab(), _rootTransformsProvider.UIRoot);

            return descriptionRow.GetComponentInChildren<DescriptionRowView>();
        }


    }
}