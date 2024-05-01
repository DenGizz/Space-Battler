using Assets.Scripts.Entities.Projectiles;
using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;

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
