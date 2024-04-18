using System.Collections;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Projectiles;
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

        private IProjectileFactory _projectileFactory;

        [Inject]
        public void Construct(IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
        }

        private void Awake()
        {
            Damage = _descriptor.Damage;
            ColdDownTime = _descriptor.ColdDownTime;
        }

        public void Tick()
        {
            if (_coldDownTimeLeft > 0)
                _coldDownTimeLeft -= Time.deltaTime;
            else
                _isOnColdDown = false;
        }

        public void Attack(ISpaceShip target)
        {
            if (_isOnColdDown)
                return;

            ProjectileBehaviour projectile =
                _projectileFactory.CreateProjectile(_descriptor.ProjectileType, transform.position, transform.rotation.eulerAngles.z);

            projectile.Lunch(target, Damage);
            _isOnColdDown = true;
            StartColdDown(ColdDownTime);
        }

        private void StartColdDown(float time)
        {
            _coldDownTimeLeft = time;
        }
    }
}
