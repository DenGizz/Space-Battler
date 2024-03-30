using Assets.Scripts.Units.UnitAttributes;
using UnityEngine;

namespace Assets.Scripts.Units
{
    public interface ISpaceShip : IDamagable, IAttackable
    {
        IHealthAttribute HealthAttribute { get; }
        Vector3 Position { get; }
    }
}
