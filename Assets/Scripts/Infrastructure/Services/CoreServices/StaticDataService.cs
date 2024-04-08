using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Weapons.WeaponConfigs;
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

        public Sprite GetSpriteFor(WeaponType weaponType)
        {
            return _assetsProvider.GetWeaponConfig(weaponType).Sprite;
        }

        public IEnumerable<WeaponConfigSO> GetWeaponConfigs()
        {
            return _assetsProvider.GetWeaponConfigs();
        }

        public IEnumerable<SpaceShipConfigSO> GetSpaceShipsConfigs()
        {
            return _assetsProvider.GetSpaceShipsConfigs();
        }

        public SpaceShipConfig GetSpaceShipConfig(SpaceShipType spaceShipType)
        {
            return GetSpaceShipsConfigs().First(config => config.CorpusType == spaceShipType).GetSpaceShipConfig();
        }
    }
}
