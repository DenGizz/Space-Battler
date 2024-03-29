using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Entities;
using UnityEngine;

[AddComponentMenu("Entities/Test/TestCombatEntity")]
public class TestCombatUnitComponent : MonoBehaviour, IUnit, IDamagable, IAttackable
{
    public IHealthAttribute HealthAttribute { get; private set; }
    public Vector3 Position => transform.position;

    public IEnumerable<IWeapon> Weapons => _weapons;

    [SerializeField] private List<WeaponComponent> _weapons;

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
