using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IAssetsProvider
    {
        GameObject GetBattleUIPrefab();
        GameObject GetSpaceShipPrefab();
        GameObject GetMainMenuUIPrefab();

        IEnumerable<SpaceShipConfigSO> GetSpaceShipConfigurationSOs();
    }
}
