using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IBattleTickService : ITickable
    {
        bool IsPaused { get; set; }

        void RegisterGameObjectTickables(GameObject gameObject);
        void UnRegisterGameObjectTickables(GameObject gameObject);
    }
}