using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.AI.AiStrategies
{
    public class SelectRandomOrLowHPTargetStrategy : ISelectTargetStrategy
    {
        private const float _lowHPThreshold = 0.25f;

        public ISpaceShip SelectTarget(IEnumerable<ISpaceShip> spaceShips)
        {
            var target = spaceShips.Where(t => t.Config.MaxHP / t.Data.HealthPoints < _lowHPThreshold).FirstOrDefault();

            return target == default ? target : spaceShips.OrderBy(x => x.Data.HealthPoints).FirstOrDefault();

        }
    }
}
