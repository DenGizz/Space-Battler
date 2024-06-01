using Assets.Scripts.Progress;

namespace Assets.Scripts.Infrastructure.Core.Services.PersistentProgressServices
{
    public interface IProgressProvider
    {
        PlayerProgressData PlayerProgressData { get; set; }
    }
}
