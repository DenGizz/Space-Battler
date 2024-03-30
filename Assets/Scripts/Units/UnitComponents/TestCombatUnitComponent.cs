using System.Collections.Generic;
using Assets.Scripts.Units.UnitAttributes;
using UnityEngine;

namespace Assets.Scripts.Units.UnitComponents
{
    [AddComponentMenu("Entities/Test/TestCombatUnit")]
    public class TestCombatUnitComponent : MonoBehaviour, ICombatUnit
    {
        public IHealthAttribute HealthAttribute { get; private set; }
        public Vector3 Position => transform.position;

        public IEnumerable<IWeapon> Weapons => _weapons;

        [SerializeField] private List<WeaponComponent> _weapons;

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
            throw new System.NotImplementedException();
        }

        public void RemoveWeapon(IWeapon weapon)
        {
            throw new System.NotImplementedException();
        }
    }
}
