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
        SpaceShipData Data { get; }
        SpaceShipConfig Config { get; }

        public event Action<ISpaceShip> OnDeath;

        void AddWeapon(IWeapon weapon);
        void RemoveWeapon(IWeapon weapon);
    }
}
