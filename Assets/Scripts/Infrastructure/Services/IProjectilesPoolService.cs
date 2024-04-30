using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Entities.Projectiles;
using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IProjectilesPoolService
    {
        void Initialize();
        ProjectileBehaviour GetProjectile(ProjectileType type);
        void ReleaseProjectile(ProjectileBehaviour projectile);
        void ClearAll();
    }
}
