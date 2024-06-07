using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.AI.AiStrategies
{
    public class UpdateTargetWhenItsDeadOrNullStrategy : IUpdateTargetStrategy
    {
        public bool IsNeedToFindNewTarget(ISpaceShip currentTarget)
        {
            return currentTarget == null || !currentTarget.Data.IsAlive;
        }
    }
}
