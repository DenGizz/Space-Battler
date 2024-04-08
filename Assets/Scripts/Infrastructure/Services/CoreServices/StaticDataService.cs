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
            return _assetsProvider.GetSpaceShipDescriptor(spaceShipType).Sprite;
        }

        public Sprite GetSpriteFor(WeaponType weaponType)
        {
            return _assetsProvider.GetWeaponDescriptor(weaponType).Sprite;
        }

        public IEnumerable<WeaponDescriptor> GetWeaponConfigs()
        {
            return _assetsProvider.GetWeaponDescriptors();
        }

        public IEnumerable<SpaceShipDescriptor> GetSpaceShipsConfigs()
        {
            return _assetsProvider.GetSpaceShipsDescriptors();
        }

        public SpaceShipConfig GetSpaceShipConfig(SpaceShipType spaceShipType)
        {
            return GetSpaceShipsConfigs().First(config => config.CorpusType == spaceShipType).GetSpaceShipConfig();
        }
    }
}
