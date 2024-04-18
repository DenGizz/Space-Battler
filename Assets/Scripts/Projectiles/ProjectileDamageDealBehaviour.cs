using System.Collections;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Projectiles
{
    [RequireComponent(typeof(ProjectileBehaviour))]
    public class ProjectileDamageDealBehaviour : MonoBehaviour, ITickable
    {
        private bool IsDamageDealt;

        private ProjectileBehaviour _projectileBehaviour;

        private void Awake()
        {
            _projectileBehaviour = GetComponent<ProjectileBehaviour>();
            _projectileBehaviour.OnReset += ResetBehaviour;
        }

        public void Tick()
        {
            if (IsDamageDealt)
            {
                return;
            }

            if (_projectileBehaviour.IsReachedTarget)
            {
                IsDamageDealt = true;
                DealDamage();
            }
        }

        private void DealDamage()
        {
            var target = _projectileBehaviour.Target;
            var damage = _projectileBehaviour.Damage;
            target.TakeDamage(damage);
        }

        public void ResetBehaviour()
        {
            IsDamageDealt = false;
        }
    }
}