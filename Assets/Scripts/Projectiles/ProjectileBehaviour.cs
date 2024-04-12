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
        private float _speed => _projectileDescriptor.Speed;
        private float _damage;

        public IDamagable Target { get; private set; }

        public bool IsLunched { get; private set; }

        [SerializeField] private ProjectileDescriptor _projectileDescriptor;

        private IAutomoveMove _automove;

        private void Awake()
        {
            _automove = GetComponentInChildren<IAutomoveMove>();
        }

        public void Lunch(ISpaceShip target, float damage)
        {
            Target = target;
            IsLunched = true;
            _automove.Speed = _projectileDescriptor.Speed;
            _automove.IsMoving = true;
            _automove.EndPoint = target.Position;
            _damage = damage;
        }

        public void ResetProjectile()
        {
            Target = null;
            IsLunched = false;
            _damage = 0;
            _automove.IsMoving = false;
        }
    }
}
