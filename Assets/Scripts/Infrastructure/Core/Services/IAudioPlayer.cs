using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public interface IAudioPlayer : IInitializable
    {
        float NormalizedMasterVolume { get; set; }

        void PlayMainMenuMusic();
        void StopMainMenuMusic();
    }
}
