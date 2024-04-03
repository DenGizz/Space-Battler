using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IStaticDataService
    {
        SpaceShip.SpaceShipConfig GetSpaceShipConfiguration(SpaceShipCorpusType corpusType);
    }
}
