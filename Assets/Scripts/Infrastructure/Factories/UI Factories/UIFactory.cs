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

        [Inject]
        public UIFactory(IAssetsProvider assetsProvider, IInstantiator instantiator)
        {
            _assetsProvider = assetsProvider;
            _instantiator = instantiator;
        }

        public (BattleUI battleUIm, GameObject gameObject) CreateBattleUI()
        {
            GameObject battleUI = GameObject.Instantiate(_assetsProvider.GetBattleUIPrefab());

            return (battleUI.GetComponentInChildren<BattleUI>(), battleUI);
        }

        public MainMenuUI CreateMainMenuUI()
        {
            GameObject mainMenuUI = GameObject.Instantiate(_assetsProvider.GetMainMenuUIPrefab());

            return mainMenuUI.GetComponentInChildren<MainMenuUI>();
        }

        public DescriptionRowView CreateWeaponDescriptionRowView()
        {
            GameObject descriptionRow = GameObject.Instantiate(_assetsProvider.GetWeaponDescriptionRowViewPrefab());

            return descriptionRow.GetComponentInChildren<DescriptionRowView>();
        }

        public WeaponSelectionPanelViewModel CreateWeaponSelectionPanelViewPanel()
        {
            GameObject prefab = _assetsProvider.GetWeaponSelectionPanelPrefab();
            GameObject weaponSelectionPanel = _instantiator.InstantiatePrefab(prefab/*, _rootTransformsProvider.GetUIRootTransform()*/);
            weaponSelectionPanel.transform.SetAsLastSibling(); //TODO: Refactor
            return weaponSelectionPanel.GetComponent<WeaponSelectionPanelViewModel>();
        }
    }
}