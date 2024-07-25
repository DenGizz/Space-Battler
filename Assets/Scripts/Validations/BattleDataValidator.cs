using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Battles
{
    public static class BattleDataValidator
    {
        public static bool IsBattleDataValid(BattleData battleData)
        {
            return IsBattleDataValid(battleData, out _);
        }

        public static bool IsBattleDataValid(BattleData battleData, out string reason)
        {
            if (battleData == null)
            {
                reason = "Battle data is null";
                return false;
            }

            if(battleData.AllyTeam.Members == null || !battleData.AllyTeam.Members.Any())
            {
                reason = "Ally team members are null or empty";
                return false;
            }

            if (battleData.EnemyTeam.Members == null || !battleData.EnemyTeam.Members.Any())
            {
                reason = "Enemy team members are null or empty";
                return false;
            }

            if (battleData.AllyTeam.Members.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                reason = "Ally team members contain duplicates";
                return false;
            }

            if (battleData.EnemyTeam.Members.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                reason = "Enemy team members contain duplicates";
                return false;
            }

            if (battleData.AllyTeam.Members.Intersect(battleData.EnemyTeam.Members).Any())
            {
                reason = "Ally and enemy team members intersect";
                return false;
            }

            reason = null;
            return true;
        }
    }
}
