using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services
{
    public class ProjectileAutoDestroyService : IProjectileAutoDestroyService, ITickable
    {

        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IProjectilesRegister _projectilesRegister;
        private readonly IBattleTickService _battleTickService;

        private readonly List<ProjectileBehaviour> _projectiles;

        [Inject]
        public ProjectileAutoDestroyService(IGameObjectRegistry gameObjectRegistry, IProjectilesRegister projectilesRegister, IBattleTickService battleTickService)
        {
            _gameObjectRegistry = gameObjectRegistry;
            _projectilesRegister = projectilesRegister;
            _battleTickService = battleTickService;
            _projectiles = new List<ProjectileBehaviour>();
        }

        public void TrackProjectile(ProjectileBehaviour projectile)
        {
            _projectiles.Add(projectile);
        }

        public void UntrackProjectile(ProjectileBehaviour projectile)
        {
            _projectiles.Remove(projectile);
        }

        private void DestroyProjectile(ProjectileBehaviour projectile)
        {
           GameObject gameObject = _gameObjectRegistry.GetProjectileGameObject(projectile);

            GameObject.Destroy(gameObject);
            _gameObjectRegistry.UnRegisterGameObject(gameObject);

            _projectilesRegister.UnRegisterProjectile(projectile);


            ITickable[] s = gameObject.GetComponentsInChildren<ITickable>();
            foreach (ITickable ss in s)
            {
                _battleTickService.RemoveTickable(ss);
            }
        }

        public void Tick()
        {
            List< ProjectileBehaviour > projectilesToDelete = new List<ProjectileBehaviour>();
            foreach (var projectile in _projectiles)
            {
                if (!projectile.IsReachedTarget) 
                    continue;

                DestroyProjectile(projectile);
                projectilesToDelete.Add(projectile);
            }

            foreach (var projectile in projectilesToDelete)
                UntrackProjectile(projectile);

            projectilesToDelete.Clear();
        }
    }
}
