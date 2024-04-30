using System;
using System.Collections.Generic;
using Assets.Scripts.Entities.SpaceShips.SpaceShipAttributes;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons;
using UnityEngine;

namespace Assets.Scripts.Entities.SpaceShips
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
