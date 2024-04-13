using Assets.Scripts.Infrastructure.Destroyers;
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
        private readonly IProjectileDestroyer _projectileDestroyer;

        private readonly List<ProjectileBehaviour> _projectiles;

        [Inject]
        public ProjectileAutoDestroyService(IProjectileDestroyer projectileDestroyer)
        {
            _projectileDestroyer = projectileDestroyer;
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


        public void Tick()
        {
            List< ProjectileBehaviour > projectilesToDelete = new List<ProjectileBehaviour>();
            foreach (var projectile in _projectiles)
            {
                if(projectile == null)
                {
                    projectilesToDelete.Add(projectile);
                    continue;
                }

                if (!projectile.IsReachedTarget) 
                    continue;

                _projectileDestroyer.Destroy(projectile);
                projectilesToDelete.Add(projectile);
            }

            foreach (var projectile in projectilesToDelete)
                UntrackProjectile(projectile);

            projectilesToDelete.Clear();
        }
    }
}
