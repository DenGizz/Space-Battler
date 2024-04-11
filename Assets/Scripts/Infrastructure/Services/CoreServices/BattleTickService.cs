using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class BattleTickService : IBattleTickService
    {
        private List<ITickable> _tickables = new List<ITickable>();

        public bool IsPaused { get; set; }

        public void AddTickable(ITickable tickable)
        {
            _tickables.Add(tickable);
        }

        public void RemoveTickable(ITickable tickable)
        {
            _tickables.Remove(tickable);
        }

        public void Tick()
        {
            if (IsPaused)
                return;

            foreach (var tickable in _tickables)
                tickable.Tick();
        }
    }
}
