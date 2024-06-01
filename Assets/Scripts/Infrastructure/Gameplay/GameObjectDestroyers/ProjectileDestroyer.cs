using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.GameObjectDestroyers
{
    public class ProjectileDestroyer : IProjectileDestroyer
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IProjectilesRegister _projectilesRegister;
        private readonly IBattleTickService _battleTickService;


        [Inject]
        public ProjectileDestroyer(IGameObjectRegistry gameObjectRegistry, IProjectilesRegister projectilesRegister, IBattleTickService battleTickService)
        {
            _gameObjectRegistry = gameObjectRegistry;
            _projectilesRegister = projectilesRegister;
            _battleTickService = battleTickService;
        }

        public void Destroy(ProjectileBehaviour projectile)
        {
            GameObject gameObject = _gameObjectRegistry.GetProjectileGameObject(projectile);

            _projectilesRegister.UnRegisterProjectile(projectile);
            _gameObjectRegistry.UnRegisterGameObject(gameObject);
            _battleTickService.UnRegisterGameObjectTickables(gameObject);

            Object.Destroy(gameObject);
        }
    }
}