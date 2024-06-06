
using UnityEngine;

namespace Assets.Scripts.Entities.Weapons
{
    public interface IWeapon : IAttackable
    {
        float Damage { get; }
        float ColdDownTime { get; }
        void Aim(Vector3 position);
        bool CanShoot { get; }
    }
}