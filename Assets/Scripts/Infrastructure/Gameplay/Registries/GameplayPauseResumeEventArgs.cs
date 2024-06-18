using System;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public class GameplayPauseResumeEventArgs : EventArgs
    {
        public bool IsPaused { get; }

        public GameplayPauseResumeEventArgs(bool isPaused)
        {
            IsPaused = isPaused;
        }
    }
}