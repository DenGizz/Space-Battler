using System.Collections;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Weapons
{
    [AddComponentMenu("Weapon")]
    public class WeaponBehaviour : MonoBehaviour, IWeapon, ITickable
    {
        public float Damage { get; private set; }
        public float ColdDownTime { get; private set; }
        public bool CanShoot => !_isOnColdDown;
        private bool _isOnColdDown;

        private float _coldDownTimeLeft;

        [SerializeField] private WeaponDescriptor _descriptor;

        private void Awake()
        {
            Damage = _descriptor.Damage;
            ColdDownTime = _descriptor.ColdDownTime;
        }

        public void Shoot(IDamagable target)
        {
            if (_isOnColdDown)
                return;

            target.TakeDamage(Damage);
            _isOnColdDown = true;
            StartColdDown(ColdDownTime);
        }

        private void StartColdDown(float time)
        {
            _coldDownTimeLeft = time;
        }

        public void Tick()
        {
           if(_coldDownTimeLeft > 0)
                _coldDownTimeLeft -= Time.deltaTime;
           else
                _isOnColdDown = false;
        }
    }
}
