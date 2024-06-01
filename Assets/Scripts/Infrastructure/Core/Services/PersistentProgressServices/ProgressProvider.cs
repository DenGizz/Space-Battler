using Assets.Scripts.Progress;

namespace Assets.Scripts.Infrastructure.Services.PersistentProgressServices
{
    public class ProgressProvider : IProgressProvider
    {
        public PlayerProgressData PlayerProgressData { get; set; }
    }
}
