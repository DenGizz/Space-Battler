using Assets.Scripts.AI.AiStrategies;

namespace Assets.Scripts.Infrastructure.Gameplay.Ai
{
    public interface IAiStrategyFactory
    {
        ISelectTargetStrategy CreateSelectTargetStrategy();
        IUpdateTargetStrategy CreateUpdateTargetStrategy();
    }
}