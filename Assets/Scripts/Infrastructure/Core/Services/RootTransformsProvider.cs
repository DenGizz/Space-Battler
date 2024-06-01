using UnityEngine;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public class RootTransformsProvider : IRootTransformsProvider
    {
        public Transform SpaceShipsRoot { get; set; }
        public Transform UIRoot { get; set; }
        public Transform ProjectilesRoot { get; set; }
    }
}
