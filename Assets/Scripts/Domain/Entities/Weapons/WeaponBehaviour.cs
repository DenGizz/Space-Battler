using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.ExtensionMethods;
using Assets.Scripts.Infrastructure.Gameplay.Services;
using Assets.Scripts.ScriptableObjects;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Entities.Weapons
{
    [AddComponentMenu("Weapon")]
    public class WeaponBehaviour : MonoBehaviour, IWeapon, ITickable
    {
        public float Damage { get; private set; }
        public float ColdDownTime { get; private set; }
        public bool CanShoot => CanAttack;

        public bool CanAttack => !_isOnColdDown;

        private bool _isOnColdDown;

        private float _coldDownTimeLeft;

        [SerializeField] private WeaponDescriptor _descriptor;

        private IProjectilesPoolService _projectilesPoolService;

        public event EventHandler<AttackEventArgs> OnAttack;

        [Inject]
        public void Construct(IProjectilesPoolService projectilesPoolService)
        {
            _projectilesPoolService = projectilesPoolService;
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

            
            ProjectileBehaviour projectile = _projectilesPoolService.GetProjectile(_descriptor.ProjectileType);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.Launch(target, Damage);
            _isOnColdDown = true;
            StartColdDown(ColdDownTime);
            OnAttack?.Invoke(this, new AttackEventArgs(this,target,Damage));
        }

        private void StartColdDown(float time)
        {
            _coldDownTimeLeft = time;
        }

        public void Aim(Vector3 position)
        {
            transform.LookAt2D(position);
        }
    }
}
