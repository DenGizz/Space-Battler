using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public interface IWeapon
    {
        float Damage { get; }
        float ColdDownTime { get; }

        bool CanShoot { get; }
        void Shoot(IDamagableEntity target);
    }
}