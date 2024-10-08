﻿using UnityEngine;
using Zenject;

namespace Assets.Scripts.Entities.Projectiles.ProjectileBehaviours
{
    [RequireComponent(typeof(ProjectileBehaviour))]
    public class ProjectileMoveBehaviour : MonoBehaviour, ITickable
    {
        private bool _isMoving;

        private ProjectileBehaviour _projectileBehaviour;

        private void Awake()
        {
            _projectileBehaviour = GetComponent<ProjectileBehaviour>();
            _projectileBehaviour.OnLaunched += OnProjectileLaunchEventHandler;
            _projectileBehaviour.OnReset += OnProjectileResetEventHandler;
        }

        public void Tick()
        {
            if (!_isMoving)
                return;

            transform.position = Vector3.MoveTowards(
                transform.position, 
                _projectileBehaviour.Data.Target.Data.Position, 
                _projectileBehaviour.Config.Speed * Time.deltaTime);
        }

        private void OnProjectileLaunchEventHandler()
        {
            _isMoving = true;
        }

        private void OnProjectileResetEventHandler()
        {
            _isMoving = false;
        }
    }
}

