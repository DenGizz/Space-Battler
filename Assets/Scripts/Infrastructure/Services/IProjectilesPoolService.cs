using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Projectiles;
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
