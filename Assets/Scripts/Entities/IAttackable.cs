using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public interface IAttackable
    {
        IEnumerable<IWeapon> Weapons { get; }
        void Attack(IWeapon weapon, IDamagable target);
        void AddWeapon(IWeapon weapon);
        void RemoveWeapon(IWeapon weapon);
    }
}