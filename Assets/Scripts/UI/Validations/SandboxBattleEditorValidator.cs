using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Game.SandboxMode.BattleSetups;
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
                message = "space_ship_type_not_selected";
                return false;
            }

            if (battleSetup.WeaponTypes.Count == 0)
            {
                message = "no_weapon_selected";
                return false;
            }

            if (battleSetup.WeaponTypes.All(w => w == WeaponType.None))
            {
                message = "no_weapon_selected"; ;
                return false;
            }

            message = string.Empty;
            return true;
        }

        public static bool IsBattleTeamSetupValid(BattleTeamSetup battleTeamSetup, out string message)
        {
            if(battleTeamSetup.SpaceShipSetups == null || battleTeamSetup.SpaceShipSetups.Count == 0)
            {
                message = "no_weapon_selected";
                return false;
            }

            foreach (var spaceShipSetup in battleTeamSetup.SpaceShipSetups)
                if (!IsSpaceShipSetupValidForBattle(spaceShipSetup, out message))
                    return false;

            message = string.Empty;
            return true;
        }


        public static bool IsBattleSetupValidForBattle(BattleSetup battleSetup, out string message)
        {
            if (!IsBattleTeamSetupValid(battleSetup.PlayerTeamSetup, out message))
            {
                message = "Player team setup is invalid. " + message;//TODO: Solve when return combined messages
                return false;
            }
              
            if (!IsBattleTeamSetupValid(battleSetup.EnemyTeamSetup, out message))
            {
                message = "Enemy team setup is invalid. " + message;//TODO: Solve when return combined messages
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}
