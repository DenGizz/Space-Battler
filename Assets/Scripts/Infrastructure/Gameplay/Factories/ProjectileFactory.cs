using Assets.Scripts.Entities.Projectiles;
using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.Factories
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstantiator _instantiator;
        private readonly IRootTransformsProvider _rootTransformsProvider;
        private readonly IGameplayTickService _gameplayTickService;
        private readonly IProjectilesRegister _projectilesRegister;
        private readonly IGameObjectRegistry _gameObjectRegistry;

        public ProjectileFactory(IStaticDataService staticDataService, IInstantiator instantiator,
            IRootTransformsProvider rootTransformsProvider, IGameplayTickService gameplayTickService, 
            IProjectilesRegister projectilesRegister, IGameObjectRegistry gameObjectRegistry)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
            _rootTransformsProvider = rootTransformsProvider;
            _gameplayTickService = gameplayTickService;
            _projectilesRegister = projectilesRegister;
            _gameObjectRegistry = gameObjectRegistry;
        }



        public ProjectileBehaviour CreateProjectile(ProjectileType projectileType, Vector3 position, float zRotation)
        {
            GameObject projectilePrefab = _staticDataService.GetProjectileDescriptor(projectileType).Prefab;
            GameObject projectileGO = _instantiator.InstantiatePrefab(projectilePrefab, position,
                Quaternion.Euler(0, 0, zRotation), _rootTransformsProvider.ProjectilesRoot);

            ITickable[] tickables = projectileGO.GetComponents<ITickable>();
            _gameplayTickService.AddTickable(tickables);

            ProjectileBehaviour projectileBehaviour = projectileGO.GetComponent<ProjectileBehaviour>();
            ProjectileData projectileData = new ProjectileData(position);
            projectileBehaviour.Construct(projectileData);
            _projectilesRegister.RegisterProjectile(projectileBehaviour);
            _gameObjectRegistry.RegisterProjectileGameObject(projectileBehaviour, projectileGO);
            return projectileGO.GetComponent<ProjectileBehaviour>();
        }
    }
}
