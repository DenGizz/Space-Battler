using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
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
        private readonly IProjectilesRegister _projectilesRegister;
        private readonly IGameObjectRegistry _gameObjectRegistry;

        public ProjectileFactory(IStaticDataService staticDataService, IInstantiator instantiator,
            IRootTransformsProvider rootTransformsProvider, IBattleTickService battleTickService, 
            IProjectilesRegister projectilesRegister, IGameObjectRegistry gameObjectRegistry)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
            _rootTransformsProvider = rootTransformsProvider;
            _battleTickService = battleTickService;
            _projectilesRegister = projectilesRegister;
            _gameObjectRegistry = gameObjectRegistry;
        }



        public ProjectileBehaviour CreateProjectile(ProjectileType projectileType, Vector3 position, float zRotation)
        {
            GameObject prefab = _staticDataService.GetProjectileDescriptor(projectileType).Prefab;
            GameObject projectile = _instantiator.InstantiatePrefab(prefab, position, Quaternion.Euler(0, 0, zRotation), _rootTransformsProvider.ProjectilesRoot);

            ITickable[] tickables = projectile.GetComponentsInChildren<ITickable>();

            foreach (ITickable tickable in tickables)
                _battleTickService.AddTickable(tickable);

            ProjectileBehaviour projectileBehaviour = projectile.GetComponent<ProjectileBehaviour>();
            _projectilesRegister.RegisterProjectile(projectileBehaviour);
            _gameObjectRegistry.RegisterProjectileGameObject(projectileBehaviour, projectile);
            return projectile.GetComponent<ProjectileBehaviour>();
        }
    }
}
