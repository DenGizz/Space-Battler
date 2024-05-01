using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Entities
{
    public interface IAttackable
    {
        void Attack(ISpaceShip target);
    }
}