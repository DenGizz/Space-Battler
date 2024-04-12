using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Projectiles
{
    public class ProjectileLinearMoveBehaviour : MonoBehaviour, IAutomoveMove, ITickable
    {
        public Vector3 EndPoint { get; set; }
        public float Speed { get; set; }
        public bool IsMoving { get; set; }

        public void Tick()
        {
            if (!IsMoving)
                return;

            transform.position = Vector3.MoveTowards(transform.position, EndPoint, Speed * Time.deltaTime);
        }
    }
}

