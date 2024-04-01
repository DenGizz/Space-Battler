using System.Collections;
using UnityEngine;

namespace Assets.Scripts.SpaceShip.SpaceShipComponents
{
    [AddComponentMenu("Weapon")]
    public class WeaponComponent : MonoBehaviour, IWeapon
    {
        public float Damage => _damage;
        public float ColdDownTime => _coldDownTime;
        public bool CanShoot => !_isOnColdDown;

        [SerializeField] private float _damage;
        [SerializeField] private float _coldDownTime;

        private bool _isOnColdDown;

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
            StartCoroutine(ColdDown(time));
        }

        private IEnumerator ColdDown(float time)
        {
            yield return new WaitForSeconds(time);
            _isOnColdDown = false;
        }
    }
}
