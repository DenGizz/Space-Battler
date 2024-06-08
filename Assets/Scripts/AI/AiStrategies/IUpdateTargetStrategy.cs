using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.AI.AiStrategies
{
    public interface IUpdateTargetStrategy
    {
        public bool IsNeedToFindNewTarget(ISpaceShip currentTarget);
    }
}
