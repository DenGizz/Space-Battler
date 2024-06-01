using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Gameplay.Services;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Entities.Weapons
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

        private IProjectilesPoolService _projectilesPoolService;

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
        }

        private void StartColdDown(float time)
        {
            _coldDownTimeLeft = time;
        }
    }
}
