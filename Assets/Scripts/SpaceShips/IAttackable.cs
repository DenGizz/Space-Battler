using System.Collections.Generic;
using Assets.Scripts.Weapons;

namespace Assets.Scripts.SpaceShips
{
    public interface IAttackable
    {
        void Attack(ISpaceShip target);
    }
}