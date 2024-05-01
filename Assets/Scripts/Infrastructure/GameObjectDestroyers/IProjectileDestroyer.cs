using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;

namespace Assets.Scripts.Infrastructure.Destroyers
{
    public interface IProjectileDestroyer
    {
        void Destroy(ProjectileBehaviour projectile);
    }
}