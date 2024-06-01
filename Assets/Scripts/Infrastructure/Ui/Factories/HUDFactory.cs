using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Ui.Services;
using Assets.Scripts.UI.HUDs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Ui.Factories
{
    public class HUDFactory : IHUDFactory
    {
        private readonly IUiAssetsProvider _uiAssetsProvider;
        private readonly IInstantiator _instantiator;
        private readonly IRootTransformsProvider _rootTransformsProvider;

        public HUDFactory(IUiAssetsProvider uiAssetsProvider, IInstantiator instantiator, IRootTransformsProvider rootTransformsProvider)
        {
            _uiAssetsProvider = uiAssetsProvider;
            _instantiator = instantiator;
            _rootTransformsProvider = rootTransformsProvider;
        }

        public PauseBattleHUD CreatePauseBattleHUD()
        {
            GameObject pauseBattleHUDprefab = _uiAssetsProvider.GetPauseBattleHUDPrefab();
            GameObject pauseBattleHUDInstance = _instantiator.InstantiatePrefab(pauseBattleHUDprefab, _rootTransformsProvider.UIRoot);
            return pauseBattleHUDInstance.GetComponent<PauseBattleHUD>();
        }
    }
}
