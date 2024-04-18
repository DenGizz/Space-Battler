using Assets.Scripts.SpaceShips.SpaceShipAttributes;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using System;
using UnityEngine;

namespace Assets.Scripts.SpaceShips
{
    public interface ISpaceShip : IDamagable, IAttackable
    {
        IHealthAttribute HealthAttribute { get; }
        event Action<ISpaceShip> OnDeath;
        Vector3 Position { get; }
        SpaceShipConfig Config { get; }
    }
}
