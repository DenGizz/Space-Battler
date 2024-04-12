using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Projectiles;
using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstantiator _instantiator;
        private readonly IRootTransformsProvider _rootTransformsProvider;
        private readonly IBattleTickService _battleTickService;

        public ProjectileFactory(IStaticDataService staticDataService, IInstantiator instantiator, IRootTransformsProvider rootTransformsProvider, IBattleTickService battleTickService)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
            _rootTransformsProvider = rootTransformsProvider;
            _battleTickService = battleTickService;
        }


        public ProjectileBehaviour CreateProjectile(ProjectileType projectileType, Vector3 position, float zRotation)
        {
            GameObject prefab = _staticDataService.GetProjectileDescriptor(projectileType).Prefab;
            GameObject projectile = _instantiator.InstantiatePrefab(prefab, position, Quaternion.Euler(0, 0, zRotation), _rootTransformsProvider.ProjectilesRoot);

            ITickable[] tickables = projectile.GetComponentsInChildren<ITickable>();

            foreach (ITickable tickable in tickables)
                _battleTickService.AddTickable(tickable);

            return projectile.GetComponent<ProjectileBehaviour>();
        }
    }
}
