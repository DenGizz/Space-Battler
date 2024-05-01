using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.SpaceShips;
using System.Collections.Generic;

namespace Assets.Scripts.Battles
{
    public class BattleData
    {
        public List<ISpaceShip> AllyTeamMembers { get; }
        public List<ISpaceShip> EnemyTeamMembers { get; }
    }
}
