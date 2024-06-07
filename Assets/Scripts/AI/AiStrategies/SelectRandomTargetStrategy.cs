using Assets.Scripts.Entities.SpaceShips;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.AI.AiStrategies
{
    public class SelectRandomTargetStrategy : ISelectTargetStrategy
    {
        public ISpaceShip SelectTarget(IEnumerable<ISpaceShip> spaceShips)
        {
            if (spaceShips == null || spaceShips.Count() == 0)
                return null;

            return spaceShips.ElementAt(UnityEngine.Random.Range(0, spaceShips.Count()));
        }
    }
}
