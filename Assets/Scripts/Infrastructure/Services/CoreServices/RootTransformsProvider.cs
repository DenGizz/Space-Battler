using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class RootTransformsProvider : IRootTransformsProvider
    {
        public Transform SpaceShipsRoot { get; set; }
        public Transform UIRoot { get; set; }   
    }
}
