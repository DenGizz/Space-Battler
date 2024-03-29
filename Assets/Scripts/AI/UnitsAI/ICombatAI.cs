using Assets.Scripts.Units;

namespace Assets.Scripts.AI.UnitsAI
{
    public interface ICombatAI
    {
        ICombatUnit Target { get; }

        bool IsInCombatState { get; }

        void SetTarget(ICombatUnit target);
        void RemoveTarget();

        void StartCombat();
        void StopCombat();
    }
}
