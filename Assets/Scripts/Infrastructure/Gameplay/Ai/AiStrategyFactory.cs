using Assets.Scripts.AI.AiStrategies;

namespace Assets.Scripts.Infrastructure.Gameplay.Ai
{
    public class AiStrategyFactory : IAiStrategyFactory
    {
        public ISelectTargetStrategy CreateSelectTargetStrategy()
        {
            return new SelectRandomTargetStrategy();
        }

        public IUpdateTargetStrategy CreateUpdateTargetStrategy()
        {
            return new UpdateTargetWhenItsDeadOrNullStrategy();
        }
    }
}