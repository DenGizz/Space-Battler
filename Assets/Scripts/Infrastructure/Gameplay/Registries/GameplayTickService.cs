using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Infrastructure.Core.Services;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
{
    public class GameplayTickService : IGameplayTickService
    {
        public bool IsPaused
        {
            get => _isPaused;
            set
            {
                _isPaused = value;
                OnPauseOrResume?.Invoke();
            }
        }

        public event Action OnPauseOrResume;

        private readonly List<ITickable> _tickables = new List<ITickable>();

        private readonly HashSet<ITickable> _tickablesToRemove = new HashSet<ITickable>();
        private readonly List<ITickable> _tickablesToAdd = new List<ITickable>();

        private bool _isPaused;

        public void AddTickable(ITickable tickable)
        {
            _tickablesToAdd.Add(tickable);
        }

        public void AddTickable(IEnumerable<ITickable> tickables)
        {
            _tickablesToAdd.AddRange(tickables);
        }

        public void RemoveTickable(ITickable tickable)
        {
            _tickablesToRemove.Add(tickable);
        }

        public void RemoveTickable(IEnumerable<ITickable> tickables)
        {
            _tickablesToRemove.AddRange(tickables);
        }

        public void Tick()
        {
            if (IsPaused)
                return;

            _tickables.AddRange(_tickablesToAdd);
            _tickablesToAdd.Clear();

            foreach (var tickable in _tickables)
            {
                if(_tickablesToRemove.Contains(tickable))
                    continue;

                tickable.Tick();
            }

            _tickables.RemoveAll(item => _tickablesToRemove.Contains(item));
            _tickablesToRemove.Clear();
        }
    }
}
