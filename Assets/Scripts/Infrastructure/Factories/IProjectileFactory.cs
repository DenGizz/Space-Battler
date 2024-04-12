using Assets.Scripts.Projectiles;
using Assets.Scripts.ScriptableObjects;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IProjectileFactory 
    {
        ProjectileBehaviour CreateProjectile(ProjectileType projectileType,Vector3 position,float zRotation);
    }
}