using Assets.Scripts.Entities.Weapons;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(WeaponType weaponType, Vector3 position, float zRotation);
    }
}