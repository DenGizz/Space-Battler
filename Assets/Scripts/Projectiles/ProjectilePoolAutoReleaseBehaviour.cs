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
    public class ProjectilePoolAutoReleaseBehaviour : MonoBehaviour,ITickable
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
        }

        public void Tick()
        {
            if (_projectileBehaviour.IsReachedTarget)
                _projectilesPoolService.ReleaseProjectile(_projectileBehaviour);
        }

    }
}
