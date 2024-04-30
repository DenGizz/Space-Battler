using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public class ProjectilesRegister : IProjectilesRegister
    {
        public IEnumerable<ProjectileBehaviour> Projectiles => _projectiles;

        private readonly List<ProjectileBehaviour> _projectiles = new List<ProjectileBehaviour>();

        public void RegisterProjectile(ProjectileBehaviour projectile)
        {
            _projectiles.Add(projectile);
        }

        public void UnRegisterAll()
        {
            _projectiles.Clear();
        }

        public void UnRegisterProjectile(ProjectileBehaviour projectile)
        {
            _projectiles.Remove(projectile);
        }
    }
}