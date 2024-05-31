using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.Validations
{
    public static class SandboxBattleEditorValidator
    {
        public static bool IsSpaceShipSetupValidForBattle(SpaceShipSetup battleSetup, out string message)
        {
            if (battleSetup.SpaceShipType == SpaceShipType.None)
            {
                message = "Space ship type is not selected.";
                return false;
            }

            if (battleSetup.WeaponTypes.Count == 0)
            {
                message = "No weapons selected.";
                return false;
            }

            if (battleSetup.WeaponTypes.All(w => w == WeaponType.None))
            {
                message = "No weapons selected."; ;
                return false;
            }

            message = string.Empty;
            return true;
        }

        public static bool IsBattleSetupValidForBattle(BattleSetup battleSetup, out string message)
        {
            if(!IsSpaceShipSetupValidForBattle(battleSetup.PlayerSetup, out message))
            {
                message = $"Player setup is invalid. {message}";
                return false;
            }

            if (!IsSpaceShipSetupValidForBattle(battleSetup.EnemySetup, out message))
            {
                message = $"Enemy setup is invalid. {message}";
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}
