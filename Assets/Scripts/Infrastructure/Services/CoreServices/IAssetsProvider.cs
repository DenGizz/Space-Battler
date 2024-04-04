using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.Weapons.WeaponConfigs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IAssetsProvider
    {
        GameObject GetBattleUIPrefab();
        GameObject GetSpaceShipPrefab();
        GameObject GetMainMenuUIPrefab();
        GameObject GetWeaponPrefab(WeaponType weaponType);

        IEnumerable<SpaceShipConfigSO> GetSpaceShipConfigurationSOs();
        IEnumerable<WeaponConfigSO> GetWeaponConfigurationSOs();
    }
}
