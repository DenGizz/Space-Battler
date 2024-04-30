using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IRandomSetupService
    {
        SpaceShipSetup GetRandomSpaceShipSetup();
    }
}
