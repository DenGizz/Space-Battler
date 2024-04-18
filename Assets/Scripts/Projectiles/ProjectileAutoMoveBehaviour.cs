using System;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Projectiles
{
    [RequireComponent(typeof(ProjectileBehaviour))]
    public class ProjectileAutoMoveBehaviour : MonoBehaviour, ITickable
    {
        public Vector3 EndPoint { get; set; }
        public float Speed { get; set; }
        public bool IsMoving { get; set; }

        private ProjectileBehaviour _projectileBehaviour;

        private void Awake()
        {
            _projectileBehaviour = GetComponent<ProjectileBehaviour>();
            _projectileBehaviour.OnTargetChanged += OnProjectileTargetChanged;
            Speed = _projectileBehaviour.Speed;

            _projectileBehaviour.OnReset += ResetBehaviour;
        }

        public void Tick()
        {
            if (!IsMoving)
                return;

            transform.position = Vector3.MoveTowards(transform.position, EndPoint, Speed * Time.deltaTime);
        }

        private void OnProjectileTargetChanged(ISpaceShip target)
        {
            if (target == null)
            {
                IsMoving = false;
                return;
            }

            IsMoving = true;
            EndPoint = target.Position;
        }

        public void ResetBehaviour()
        {
            IsMoving = false;
            EndPoint = Vector3.zero;
        }
    }
}

