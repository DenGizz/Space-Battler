using System;

namespace Assets.Scripts.UI.Uis
{
    public interface IGameStateChangeEventSource
    {
        public event Action<GameStateChangeEvent> OnGameStateChangeEvent;
    }
}
