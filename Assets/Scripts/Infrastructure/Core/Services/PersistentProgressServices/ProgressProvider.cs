using Assets.Scripts.Progress;

namespace Assets.Scripts.Infrastructure.Core.Services.PersistentProgressServices
{
    public class ProgressProvider : IProgressProvider
    {
        public PlayerProgressData PlayerProgressData { get; set; }
    }
}
