using Assets.Scripts.SpaceShips.SpaceShipAttributes;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using System;
using System.Collections.Generic;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.SpaceShips
{
    public interface ISpaceShip : IDamagable, IAttackable
    {
        IHealthAttribute HealthAttribute { get; }
        event Action<ISpaceShip> OnDeath;
        bool IsDead { get; }
        Vector3 Position { get; }
        SpaceShipConfig Config { get; }

        IEnumerable<IWeapon> Weapons { get; }
        void AddWeapon(IWeapon weapon);
        void RemoveWeapon(IWeapon weapon);
    }
}
