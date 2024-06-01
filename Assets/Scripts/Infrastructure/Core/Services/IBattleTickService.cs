using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public interface IBattleTickService : ITickable
    {
        bool IsPaused { get; set; }

        void RegisterGameObjectTickables(GameObject gameObject);
        void UnRegisterGameObjectTickables(GameObject gameObject);
    }
}