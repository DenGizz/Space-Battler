using System.Collections.Generic;
using Assets.Scripts.Units.UnitAttributes;
using UnityEngine;

namespace Assets.Scripts.Units.UnitComponents
{
    [AddComponentMenu("Units/SpaceShip")]
    public class SpaceShipUnitComponent : MonoBehaviour, ICombatUnit
    {
        public IHealthAttribute HealthAttribute { get; private set; }

        public Vector3 Position => transform.position;

        public IEnumerable<IWeapon> Weapons => _weapons;

        private List<IWeapon> _weapons;

        private void Awake()
        {
            HealthAttribute = new HealthAttribute(100,100);
        }

        public void TakeDamage(float damageAmount)
        {
            HealthAttribute.TakeDamage(damageAmount);
        }
    
        public void Attack(IWeapon weapon, IDamagable target)
        {
            weapon.Shoot(target);
        }

        public void AddWeapon(IWeapon weapon)
        {
            _weapons.Add(weapon);
        }

        public void RemoveWeapon(IWeapon weapon)
        {
            _weapons.Remove(weapon);
        }
    }
}