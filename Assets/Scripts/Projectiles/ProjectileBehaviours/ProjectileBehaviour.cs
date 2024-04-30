using Assets.Scripts.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Projectiles;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Zenject;

namespace Assets.Scripts.ScriptableObjects
{
    public class ProjectileBehaviour : MonoBehaviour, IProjectile, ITickable
    {
        public ProjectileData Data {get; private set;}
        public ProjectileConfig Config { get; private set; }

        public event Action OnLaunched;
        public event Action OnReset;
        public event Action OnReachedTarget;

        [SerializeField] private ProjectileDescriptor _descriptor;

        public void Construct(Vector3 position)
        {
            Data = new ProjectileData(transform.position);
            Config = new ProjectileConfig(_descriptor.ProjectileType, _descriptor.Speed);
        }

        public void Construct(ProjectileData data)
        {
            Data = data;
            Config = new ProjectileConfig(_descriptor.ProjectileType, _descriptor.Speed);
        }

        public void Launch(ISpaceShip target, float damage)
        {
            Data.Target = target;
            Data.IsLaunched = true;
            Data.Damage = damage;
            OnLaunched?.Invoke();
        }

        public void Reset()
        {
            Data.IsLaunched = false;
            Data.IsReachedTarget = false;
        }

        public void Tick()
        {
            Data.Position = transform.position;

            if (!Data.IsLaunched)
                return;

            if (Data.IsReachedTarget)
                return;

            if ( Vector3.Distance(Data.Target.Position, Data.Position) < 0.05)
            {
                Data.IsReachedTarget = true;
                OnReachedTarget?.Invoke();
            }
        }
    }
}
