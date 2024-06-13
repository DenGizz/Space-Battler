using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.AI.AiStrategies
{
    public interface IUpdateTargetStrategy
    {
        public bool IsNeedToFindNewTarget(ISpaceShip currentTarget);
    }
}
