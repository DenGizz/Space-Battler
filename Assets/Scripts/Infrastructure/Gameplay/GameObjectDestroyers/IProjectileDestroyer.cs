using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;

namespace Assets.Scripts.Infrastructure.Gameplay.GameObjectDestroyers
{
    public interface IProjectileDestroyer
    {
        void Destroy(ProjectileBehaviour projectile);
    }
}