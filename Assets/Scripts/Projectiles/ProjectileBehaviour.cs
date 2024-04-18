﻿using Assets.Scripts.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Projectiles;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Zenject;

namespace Assets.Scripts.ScriptableObjects
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        public float Speed => _projectileDescriptor.Speed;
        public float Damage;

        public ISpaceShip Target { get; private set; }
        public bool IsReachedTarget => Vector3.Distance(transform.position, Target.Position) < 0.1f;
        public Action<ISpaceShip> OnTargetChanged;

        [SerializeField] private ProjectileDescriptor _projectileDescriptor;


        public void Lunch(ISpaceShip target, float damage)
        {
            Target = target;
            Damage = damage;

            OnTargetChanged?.Invoke(target);
        }
    }
}
