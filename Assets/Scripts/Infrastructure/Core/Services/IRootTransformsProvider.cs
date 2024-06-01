using UnityEngine;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public interface IRootTransformsProvider
    {
        Transform SpaceShipsRoot { get; set; }
        Transform UIRoot { get; set; }
        Transform ProjectilesRoot { get; set; }
    }
}
