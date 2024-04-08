﻿using Assets.Scripts.Weapons.WeaponConfigs;
using System.Collections;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(WeaponType weaponType, Vector3 position, float zRotation);
    }
}