using Assets.Scripts.AI.AiStrategies;
using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Ai
{
    public interface IAiStrategyFactory
    {
        IUpdateTargetStrategy CreateUpdateTargetStrategy();
    }
}
