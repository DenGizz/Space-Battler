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


            return (battleUi.GetComponentInChildren<BattleUI>(), battleUI: battleUi);
        }

        public MainMenuUI CreateMainMenuUi()
        {
            GameObject mainMenuUi = _instantiator.InstantiatePrefab(_assetsProvider.GetMainMenuUIPrefab(), _rootTransformsProvider.UIRoot);

            return mainMenuUi.GetComponentInChildren<MainMenuUI>();
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


    }
}