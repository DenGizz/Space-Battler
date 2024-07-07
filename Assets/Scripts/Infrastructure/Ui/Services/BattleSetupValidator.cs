using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Game.SandboxMode.BattleSetups;
using Assets.Scripts.Infrastructure.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Ui.Services
{
    public class BattleSetupValidator
    {
        private readonly IStringLocalizer _stringLocalizer;

        public BattleSetupValidator(IStringLocalizer stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public bool IsSpaceShipSetupValidForBattle(SpaceShipSetup battleSetup, out string message)
        {
            if (battleSetup.SpaceShipType == SpaceShipType.None)
            {
                message = GetLocalizedByKey("space_ship_type_not_selected");
                return false;
            }

            if (battleSetup.WeaponTypes.Count == 0)
            {
                message = GetLocalizedByKey("no_weapon_selected");
                return false;
            }

            if (battleSetup.WeaponTypes.All(w => w == WeaponType.None))
            {
                message = GetLocalizedByKey("no_weapon_selected");
                return false;
            }

            message = string.Empty;
            return true;
        }

        public bool IsBattleTeamSetupValid(BattleTeamSetup battleTeamSetup, out string message)
        {
            if (battleTeamSetup.SpaceShipSetups == null || battleTeamSetup.SpaceShipSetups.Count == 0)
            {
                message = GetLocalizedByKey("no_weapon_selected");
                return false;
            }

            foreach (var spaceShipSetup in battleTeamSetup.SpaceShipSetups)
                if (!IsSpaceShipSetupValidForBattle(spaceShipSetup, out message))
                    return false;

            message = string.Empty;
            return true;
        }


        public bool IsBattleSetupValidForBattle(BattleSetup battleSetup, out string message)
        {
            if (!IsBattleTeamSetupValid(battleSetup.PlayerTeamSetup, out message))
            {
                message = $"{GetLocalizedByKey("ally_team_setup_invalid")}. {GetLocalizedByKey(message)}";
                return false;
            }

            if (!IsBattleTeamSetupValid(battleSetup.EnemyTeamSetup, out message))
            {
                message = $"{GetLocalizedByKey("enemy_team_setup_invalid")}. {GetLocalizedByKey(message)}";
                return false;
            }

            message = string.Empty;
            return true;
        }

        private string GetLocalizedByKey(string stringKey)
        {
            return _stringLocalizer.GetLocalizedString(stringKey);
        }
    }
}
