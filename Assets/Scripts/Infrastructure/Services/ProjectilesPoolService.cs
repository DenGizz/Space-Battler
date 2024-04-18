using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Pools;
using Assets.Scripts.Projectiles;
using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services
{
    public class ProjectilesPoolService : IProjectilesPoolService
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticDataService;
        private readonly Dictionary<ProjectileType, ProjectilesPool> _projectilesPools;

        public ProjectilesPoolService(IStaticDataService staticDataService, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _staticDataService = staticDataService;
            _projectilesPools = new Dictionary<ProjectileType, ProjectilesPool>();
            Initialize();
        }

        public void Initialize()
        {
            IEnumerable<ProjectileDescriptor> descriptors = _staticDataService.GetProjectilesDescriptors();

            foreach (ProjectileDescriptor descriptor in descriptors)
            {
                ProjectilesPool pool = _instantiator.Instantiate<ProjectilesPool>(new object[] { descriptor.ProjectileType });
                _projectilesPools.Add(descriptor.ProjectileType, pool);
            }
        }

        public ProjectileBehaviour GetProjectile(ProjectileType type)
        {
            return _projectilesPools[type].Get();
        }


        public void ReleaseProjectile(ProjectileBehaviour projectile)
        {
            _projectilesPools[projectile.Type].Release(projectile);
        }

        public void ClearAll()
        {
            foreach (var pool in _projectilesPools.Values)
                pool.Clear();
        }
    }
}
