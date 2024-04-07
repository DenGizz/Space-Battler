using System.Collections;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.UI;
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
            GameObject mainMenuUI = GameObject.Instantiate(_assetsProvider.GetMainMenuUIPrefab(), _rootTransformsProvider.UIRoot);

            return mainMenuUI.GetComponentInChildren<MainMenuUI>();
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
    }
}