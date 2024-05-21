using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs
{
    public static class SpaceShipSetupValidator
    {
        public static bool IsSpaceShipSetupValid(SpaceShipSetup setup, out string reason)
        {
            if (setup == null)
            {
                reason = "SpaceShipSetup is null";
                return false;
            }

            if (setup.WeaponTypes == null)
            { 
                reason = "SpaceShipSetup WeaponTypes is null";
                return false;
            }

            if (setup.SpaceShipType == SpaceShipType.None && setup.WeaponTypes.Any())
            {
                reason = "SpaceShipType is None but has weapons";
                return false;
            }

            reason = string.Empty;
            return true;
        }
    }
}
