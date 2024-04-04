using Assets.Scripts.Weapons.WeaponConfigs;
using System.Collections;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.SpaceShip.SpaceShipComponents
{
    [AddComponentMenu("Weapon")]
    public class WeaponComponent : MonoBehaviour, IWeapon
    {
        public float Damage { get; private set; }
        public float ColdDownTime { get; private set; }
        public bool CanShoot => !_isOnColdDown;
        private bool _isOnColdDown;

        [SerializeField] private WeaponConfigSO _config;

        private void Awake()
        {
            Damage = _config.Damage;
            ColdDownTime = _config.ColdDownTime;
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
            StartCoroutine(ColdDown(time));
        }

        private IEnumerator ColdDown(float time)
        {
            yield return new WaitForSeconds(time);
            _isOnColdDown = false;
        }
    }
}
