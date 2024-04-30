using System.Collections;
using Assets.Scripts.Entities.Projectiles.ProjectileBehaviours;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Destroyers
{
    public interface IProjectileDestroyer
    {
        void Destroy(ProjectileBehaviour projectile);
    }
}