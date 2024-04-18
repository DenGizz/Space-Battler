using Assets.Scripts.SpaceShips;

namespace Assets.Scripts.AI.UnitsAI
{
    public interface ICombatAi
    {
        void SetTarget(ISpaceShip target);

        void StartCombat();
        void StopCombat();
    }
}
