using Assets.Scripts.SpaceShips;

namespace Assets.Scripts.AI.UnitsAI
{
    public interface ICombatAI
    {
        ISpaceShip Target { get; }

        bool IsInCombatState { get; }

        void SetTarget(ISpaceShip target);
        void RemoveTarget();

        void StartCombat();
        void StopCombat();
    }
}
