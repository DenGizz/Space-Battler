using Assets.Scripts.Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.PersistentProgressServices
{
    public interface IProgressProvider
    {
        PlayerProgressData PlayerProgressData { get; set; }
    }
}
