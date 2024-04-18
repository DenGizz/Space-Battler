using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.ScriptableObjects;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Destroyers
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

            ITickable[] tickableBehaviours = gameObject.GetComponentsInChildren<ITickable>();

            foreach (var tickableBehaviour in tickableBehaviours)
                _battleTickService.RemoveTickable(tickableBehaviour);

            Object.Destroy(gameObject);
        }
    }
}