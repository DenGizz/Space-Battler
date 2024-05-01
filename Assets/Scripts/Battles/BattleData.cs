
using System.Collections.Generic;
using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Battles
{
    public class BattleData
    {
        public List<ISpaceShip> AllyTeamMembers { get; }
        public List<ISpaceShip> EnemyTeamMembers { get; }
        public bool IsBattleActive { get; set; }

        public BattleData()
        {
            AllyTeamMembers = new List<ISpaceShip>();
            EnemyTeamMembers = new List<ISpaceShip>();
        }
    }
}
