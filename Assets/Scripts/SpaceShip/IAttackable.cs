using System.Collections.Generic;

namespace Assets.Scripts.SpaceShip
{
    public interface IAttackable
    {
        IEnumerable<IWeapon> Weapons { get; }
        void Attack(IWeapon weapon, IDamagable target);
        void AddWeapon(IWeapon weapon);
        void RemoveWeapon(IWeapon weapon);
    }
}