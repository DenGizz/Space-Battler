using Assets.Scripts.Progress;

namespace Assets.Scripts.Infrastructure.Services.PersistentProgressServices
{
    public interface IProgressProvider
    {
        PlayerProgressData PlayerProgressData { get; set; }
    }
}
