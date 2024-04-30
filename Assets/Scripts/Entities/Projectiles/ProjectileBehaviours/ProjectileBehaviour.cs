using System;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Entities.Projectiles.ProjectileBehaviours
{
    public class ProjectileBehaviour : MonoBehaviour, IProjectile, ITickable
    {
        public ProjectileData Data {get; private set;}
        public ProjectileConfig Config { get; private set; }

        public event Action OnLaunched;
        public event Action OnReset;
        public event Action OnReachedTarget;

        [SerializeField] private ProjectileDescriptor _descriptor;

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

            if (!(Vector3.Distance(Data.Target.Data.Position, Data.Position) < 0.05)) 
                return;

            Data.IsReachedTarget = true;
            OnReachedTarget?.Invoke();
        }
    }
}
