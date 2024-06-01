using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public interface IBattleTickService : ITickable
    {
        public event Action OnPauseOrResume;
        bool IsPaused { get; set; }

        void RegisterGameObjectTickables(GameObject gameObject);
        void UnRegisterGameObjectTickables(GameObject gameObject);
    }
}