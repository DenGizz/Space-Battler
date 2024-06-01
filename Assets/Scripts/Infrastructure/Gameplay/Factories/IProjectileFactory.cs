using Assets.Scripts.Entities.Projectiles;
using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Gameplay.Factories
{
    public interface IProjectileFactory 
    {
        ProjectileBehaviour CreateProjectile(ProjectileType projectileType,Vector3 position,float zRotation);
    }
}