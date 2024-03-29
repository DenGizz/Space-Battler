using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public interface IAttackableEntity
    {
        IEnumerable<IWeapon> Weapons { get; }
        void Attack(IWeapon weapon, IDamagableEntity target);
        void AddWeapon(IWeapon weapon);
        void RemoveWeapon(IWeapon weapon);
    }
}