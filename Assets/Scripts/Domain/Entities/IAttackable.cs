using Assets.Scripts.Entities.SpaceShips;
using System;

namespace Assets.Scripts.Entities
{
    public interface IAttackable
    {
        public event EventHandler<AttackEventArgs> OnAttack;
        void Attack(ISpaceShip target);
        bool CanAttack { get; }
    }
}