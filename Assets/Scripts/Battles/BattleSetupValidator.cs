using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;

namespace Assets.Scripts.Battles
{
    public static class BattleSetupValidator
    {
        public static bool IsBattleSetupValidForStartBattle(BattleSetup setup)
        {
            if (setup == null)
                return false;

            return IsSpaceShipSetupValid(setup.PlayerSetup) && IsSpaceShipSetupValid(setup.EnemySetup);
        }

        private static bool IsSpaceShipSetupValid(SpaceShipSetup setup)
        {
            if (setup?.SpaceShipType == null)
                return false;

            return setup.WeaponTypes != null && setup.WeaponTypes.Any();
        }
    }
}
