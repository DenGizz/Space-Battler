using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.AI.UnitsAI
{
    public interface ICombatAi
    {
        ISpaceShip Target { get; set; }
    }
}
