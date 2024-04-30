using System.Collections;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Projectiles
{
    [RequireComponent(typeof(ProjectileBehaviour))]
    public class ProjectileDamageDealBehaviour : MonoBehaviour
    {
        private bool _isDamageDealed;
        private ProjectileBehaviour _projectileBehaviour;

        private void Awake()
        {
            _projectileBehaviour = GetComponent<ProjectileBehaviour>();
            _projectileBehaviour.OnLaunched += OnProjectileLaunchEventHandler;
            _projectileBehaviour.OnReset += OnProjectileResetEventHandler;
            _projectileBehaviour.OnReachedTarget += OnProjectileReachTargetEventHandler;
        }


        private void DealDamage()
        {
            var target = _projectileBehaviour.Data.Target;
            var damage = _projectileBehaviour.Data.Damage;
            target.TakeDamage(damage);
        }

        private void OnProjectileLaunchEventHandler()
        {
            _isDamageDealed = false;
        }

        private void OnProjectileResetEventHandler()
        {
            _isDamageDealed = false;
        }

        private void OnProjectileReachTargetEventHandler()
        {
            if (_isDamageDealed)
                return;

            DealDamage();
            _isDamageDealed = true;
        }
    }
}