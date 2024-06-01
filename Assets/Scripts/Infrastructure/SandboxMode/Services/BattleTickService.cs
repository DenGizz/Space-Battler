using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Infrastructure.Core.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
{
    public class BattleTickService : IBattleTickService
    {
        private List<ITickable> _tickables = new List<ITickable>();

        private List<ITickable> tickablesToAdd = new List<ITickable>();
        private List<ITickable> tickablesToRemove = new List<ITickable>();

        public bool IsPaused { get; set; }

        public void RegisterGameObjectTickables(GameObject gameObject)
        {
            ITickable[] tickables = gameObject.GetComponentsInChildren<ITickable>();
            tickablesToAdd.AddRange(tickables);
        }

        public void UnRegisterGameObjectTickables(GameObject gameObject)
        {
            ITickable[] tickables = gameObject.GetComponentsInChildren<ITickable>();
            tickablesToRemove.AddRange(tickables);
        }

        public void Tick()
        {
            if (IsPaused)
                return;

            _tickables.AddRange(tickablesToAdd);
            _tickables = _tickables.Except(tickablesToRemove).ToList();

            tickablesToAdd.Clear();
            tickablesToRemove.Clear();

            foreach (var tickable in _tickables)
                tickable.Tick();

        }
    }
}
