using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public interface IGameplayTickService : ITickable
    {
        event Action OnPauseOrResume;
        bool IsPaused { get; set; }

        void AddTickable(ITickable tickable);
        void AddTickable(IEnumerable<ITickable> tickables);

        void RemoveTickable(ITickable tickable);
        void RemoveTickable(IEnumerable<ITickable> tickables);  
    }
}