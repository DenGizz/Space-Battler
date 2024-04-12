using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IProjectileAutoDestroyService 
    {
         void TrackProjectile(ProjectileBehaviour projectile);
         void UntrackProjectile(ProjectileBehaviour projectile);
    }
}