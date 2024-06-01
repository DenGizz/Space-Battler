using System.Collections.Generic;
using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;

namespace Assets.Scripts.Infrastructure.Gameplay.Registries
{
    public interface IProjectilesRegister 
    {
        IEnumerable<ProjectileBehaviour> Projectiles { get; }
        void RegisterProjectile(ProjectileBehaviour projectile);
        void UnRegisterProjectile(ProjectileBehaviour projectile);
        void UnRegisterAll();
    }
}