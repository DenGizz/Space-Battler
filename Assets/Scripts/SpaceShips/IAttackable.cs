using System.Collections.Generic;
using Assets.Scripts.Weapons;

namespace Assets.Scripts.SpaceShips
{
    public interface IAttackable
    {
        IEnumerable<IWeapon> Weapons { get; }
        void Attack(IWeapon weapon, ISpaceShip target);
        void AddWeapon(IWeapon weapon);
        void RemoveWeapon(IWeapon weapon);
    }
}