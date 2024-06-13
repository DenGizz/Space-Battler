using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Ai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.AI.AiStrategies
{
    public class UpdateTargetWithDamagePrediction : UpdateTargetWhenItsDeadOrNullStrategy
    {
        private readonly IPredictDealedDamageService _predictDealedDamageService;

        public UpdateTargetWithDamagePrediction(IPredictDealedDamageService predictDealedDamageService)
        {
            _predictDealedDamageService = predictDealedDamageService;
        }

        override public bool IsNeedToFindNewTarget(ISpaceShip currentTarget)
        {
            if(base.IsNeedToFindNewTarget(currentTarget))
                return true;
            float f = _predictDealedDamageService.PredictDealedDamage(currentTarget);

            if (currentTarget.Config.MaxHP - f < 0)
            {
                int wswsws = 2;
            }

            return currentTarget.Config.MaxHP - f < 0;
        }


    }
}
