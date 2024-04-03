using Assets.Scripts.SpaceShip;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
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

        public SpaceShipConfig GetSpaceShipConfiguration(SpaceShipCorpusType corpusType)
        {
            var configs = _assetsProvider.GetSpaceShipConfigurationSOs();

            return configs.FirstOrDefault(c => c.CorpusType == corpusType)?.GetSpaceShipConfig();
        }
    }
}
