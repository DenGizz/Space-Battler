using Assets.Scripts.AI.UnitsAI;
<<<<<<< HEAD
using Assets.Scripts.Entities.SpaceShips;
=======
using Assets.Scripts.SpaceShips;
using System.Collections.Generic;
>>>>>>> parent of 015454a (Revert "Refactor Battle to BattleRunner. Change BattleData implementation")

namespace Assets.Scripts.Battles
{
    public class BattleData
    {
        public List<ISpaceShip> AllyTeamMembers { get; }
        public List<ISpaceShip> EnemyTeamMembers { get; }
    }
}
