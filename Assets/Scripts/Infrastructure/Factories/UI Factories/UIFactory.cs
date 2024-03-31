using System.Collections;
using Assets.Scripts.Infrastructure.Services;
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

        public BattleUI CreateBattleUI()
        {
            GameObject battleUI = GameObject.Instantiate(_assetsProvider.GetBattleUIPrefab());

            return battleUI.GetComponentInChildren<BattleUI>();
        }
    }
}