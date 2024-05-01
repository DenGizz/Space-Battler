using System.Linq;
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
