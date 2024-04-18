using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public interface IProjectilesRegister 
    {
        IEnumerable<ProjectileBehaviour> Projectiles { get; }
        void RegisterProjectile(ProjectileBehaviour projectile);
        void UnRegisterProjectile(ProjectileBehaviour projectile);
        void UnRegisterAll();
    }
}