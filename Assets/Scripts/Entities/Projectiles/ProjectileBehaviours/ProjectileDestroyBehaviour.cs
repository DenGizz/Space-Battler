using Assets.Scripts.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Entities.Projectiles.ProjectileBehaviours
{
    [RequireComponent(typeof(ProjectileBehaviour))]
    public class ProjectileDestroyBehaviour : MonoBehaviour
    {
        private IProjectilesPoolService _projectilesPoolService;
        private ProjectileBehaviour _projectileBehaviour;

        [Inject]
        private void Construct(IProjectilesPoolService projectilesPoolService)
        {
            _projectilesPoolService = projectilesPoolService;
        }

        private void Awake()
        {
            _projectileBehaviour = GetComponent<ProjectileBehaviour>();
            _projectileBehaviour.OnReachedTarget += OnProjectileReachedTargetEventHandler;
        }

        private void OnProjectileReachedTargetEventHandler()
        {
            _projectilesPoolService.ReleaseProjectile(_projectileBehaviour);
        }
    }
}
