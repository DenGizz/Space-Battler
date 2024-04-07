using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IRootTransformsProvider
    {
        Transform SpaceShipsRoot { get; set; }
        Transform UIRoot { get; set; }
    }
}
