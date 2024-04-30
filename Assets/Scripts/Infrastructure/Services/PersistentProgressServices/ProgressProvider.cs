using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.PersistentProgressServices
{
    public class ProgressProvider : IProgressProvider
    {
        public PlayerProgressData PlayerProgressData { get; set; }
    }
}
