using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IRootTransformsProvider
    {
        Transform SpaceShipsRoot { get; set; }
        Transform UIRoot { get; set; }
        Transform ProjectilesRoot { get; set; }
    }
}
