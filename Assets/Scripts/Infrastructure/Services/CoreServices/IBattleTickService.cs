using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IBattleTickService : ITickable
    {
        bool IsPaused { get; set; }

        public void AddTickable(ITickable tickable);

        public void RemoveTickable(ITickable tickable);
    }
}