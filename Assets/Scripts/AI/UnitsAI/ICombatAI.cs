using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.AI.UnitsAI
{
    public interface ICombatAi
    {
        void SetTarget(ISpaceShip target);

        void EnterCombatMode();
        void ExitCombatMode();
    }
}
