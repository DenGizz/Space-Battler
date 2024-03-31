using System.Collections;
using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public class UIFactory : IUIFactory
    {
        IAssetsProvider _assetsProvider;

        public UIFactory(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public BattleUI CreateBattleUI()
        {
            GameObject battleUI = GameObject.Instantiate(_assetsProvider.GetBattleUIPrefab());

            return battleUI.GetComponent<BattleUI>();
        }
    }
}