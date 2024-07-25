
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Battles
{
    public class BattleData
    {
        public BattleTeam AllyTeam { get; }
        public BattleTeam EnemyTeam { get; }
        public bool IsBattleActive { get; set; }

        public BattleData()
        {
            AllyTeam = new BattleTeam();
            EnemyTeam = new BattleTeam();
        }
    }
}
