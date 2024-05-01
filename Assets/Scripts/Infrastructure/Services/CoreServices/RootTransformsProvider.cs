using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class RootTransformsProvider : IRootTransformsProvider
    {
        public Transform SpaceShipsRoot { get; set; }
        public Transform UIRoot { get; set; }
        public Transform ProjectilesRoot { get; set; }
    }
}
