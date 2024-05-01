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

            if(battleData.AllyTeamMembers == null || battleData.AllyTeamMembers.Count == 0)
            {
                reason = "Ally team members are null or empty";
                return false;
            }

            if (battleData.EnemyTeamMembers == null || battleData.EnemyTeamMembers.Count == 0)
            {
                reason = "Enemy team members are null or empty";
                return false;
            }

            if (battleData.AllyTeamMembers.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                reason = "Ally team members contain duplicates";
                return false;
            }

            if (battleData.EnemyTeamMembers.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                reason = "Enemy team members contain duplicates";
                return false;
            }

            if (battleData.AllyTeamMembers.Intersect(battleData.EnemyTeamMembers).Any())
            {
                reason = "Ally and enemy team members intersect";
                return false;
            }

            reason = null;
            return true;
        }
    }
}
