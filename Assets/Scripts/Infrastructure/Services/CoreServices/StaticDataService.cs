using Assets.Scripts.SpaceShip;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using Assets.Scripts.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetsProvider _assetsProvider;

        public StaticDataService(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public SpaceShipConfig GetSpaceShipConfiguration(SpaceShipType corpusType)
        {
            var configs = _assetsProvider.GetSpaceShipConfigurationSOs();

            return configs.FirstOrDefault(c => c.CorpusType == corpusType)?.GetSpaceShipConfig();
        }

        public WeaponConfig GetWeaponConfiguration(WeaponType weaponType)
        {
            var configs = _assetsProvider.GetWeaponConfigurationSOs();

            return configs.FirstOrDefault(c => c.WeaponType == weaponType)?.GetWeaponConfig();
        }
    }
}
