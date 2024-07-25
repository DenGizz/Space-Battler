using System;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons;
using UnityEngine;

namespace Assets.Scripts.Entities.SpaceShips
{
    public interface ISpaceShip : IDamagable, IAttackable
    {
        SpaceShipData Data { get; }
        SpaceShipConfig Config { get; }

        event Action<ISpaceShip> OnDeath;

        void SetPosition(Vector3 position);
        void SetRotation(float zRotation);
        void AddWeapon(IWeapon weapon);
        void RemoveWeapon(IWeapon weapon);
    }
}
