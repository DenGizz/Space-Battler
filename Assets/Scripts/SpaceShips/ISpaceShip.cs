using Assets.Scripts.SpaceShips.SpaceShipAttributes;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.SpaceShips
{
    public interface ISpaceShip : IDamagable, IAttackable
    {
        IHealthAttribute HealthAttribute { get; }
        Vector3 Position { get; }
        SpaceShipConfig Config { get; }
    }
}
