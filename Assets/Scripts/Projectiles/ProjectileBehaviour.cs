using Assets.Scripts.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Projectiles;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.ScriptableObjects
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        public float Speed => _projectileDescriptor.Speed;
        private float _damage;

        public ISpaceShip Target { get; private set; }
        public bool IsReachedTarget => Vector3.Distance(transform.position, Target.Position) < 0.1f;
        public Action<ISpaceShip> OnTargetChanged;

        [SerializeField] private ProjectileDescriptor _projectileDescriptor;


        public void Lunch(ISpaceShip target, float damage)
        {
            Target = target;
            _damage = damage;

            OnTargetChanged?.Invoke(target);
        }
    }
}
