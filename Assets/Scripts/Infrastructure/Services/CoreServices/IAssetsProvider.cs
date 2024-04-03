using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IAssetsProvider
    {
        GameObject GetBattleUIPrefab();
        GameObject GetSpaceShipPrefab();
        GameObject GetMainMenuUIPrefab();
    }
}
