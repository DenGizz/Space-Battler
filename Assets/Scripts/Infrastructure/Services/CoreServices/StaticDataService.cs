using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetsProvider _assetsProvider;

        public StaticDataService(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public Sprite GetSpriteFor(SpaceShipType spaceShipType)
        {
            return _assetsProvider.GetSpaceShipConfig(spaceShipType).Sprite;
        }

        public IEnumerable<WeaponConfigSO> GetWeaponConfigs()
        {
            return _assetsProvider.GetWeaponConfigs();
        }
    }
}
