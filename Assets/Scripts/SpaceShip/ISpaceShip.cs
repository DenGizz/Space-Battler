using Assets.Scripts.SpaceShip.SpaceShipAttributes;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.SpaceShip
{
    public interface ISpaceShip : IDamagable, IAttackable
    {
        IHealthAttribute HealthAttribute { get; }
        Vector3 Position { get; }
        SpaceShipConfig Config { get; }
    }
}
