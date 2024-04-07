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

        [Inject]
        public UIFactory(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
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

        public WeaponSelectionPanelViewModel WeaponSelectionPanelViewPanel()
        {
            GameObject weaponSelectionPanel = GameObject.Instantiate(_assetsProvider.GetWeaponSelectionPanelPrefab());

            return weaponSelectionPanel.GetComponentInChildren<WeaponSelectionPanelViewModel>();
        }
    }
}