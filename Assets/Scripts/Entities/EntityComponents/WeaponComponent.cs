using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Entities;
using UnityEngine;

public class WeaponComponent : MonoBehaviour, IWeapon
{
    public float Damage { get; }
    public float ColdDownTime { get; }
    public bool CanShoot => !_isOnColdDown;

    [SerializeField] private float _damage;
    [SerializeField] private float _coldDownTime;
    private bool _isOnColdDown;

    public void Shoot(IDamagableEntity target)
    {
        if (_isOnColdDown)
            return;

        target.TakeDamage(Damage);
        _isOnColdDown = true;
        StartColdDown(ColdDownTime);
    }

    private void StartColdDown(float time)
    {
        StartCoroutine(ColdDown(time));
    }

    private IEnumerator ColdDown(float time)
    {
        yield return new WaitForSeconds(time);
        _isOnColdDown = false;
    }
}
