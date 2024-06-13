using Assets.Scripts.AI.AiStrategies;
using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Infrastructure.Ai
{
    public class AiStrategyFactory : IAiStrategyFactory
    {
        private readonly IInstantiator _instantiator;

        public AiStrategyFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public IUpdateTargetStrategy CreateUpdateTargetStrategy()
        {
            return _instantiator.Instantiate<UpdateTargetWithDamagePrediction>();
        }
    }
}
