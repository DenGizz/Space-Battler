using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Projectiles
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
