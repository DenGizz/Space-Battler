using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.Weapons.WeaponConfigs;
using System.Collections.Generic;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IAssetsProvider
    {
        GameObject GetSpaceShipPrefab(SpaceShipType spaceShipType);
        GameObject GetWeaponPrefab(WeaponType weaponType);

        GameObject GetBattleUIPrefab();
        GameObject GetMainMenuUIPrefab();
        GameObject GetWeaponDescriptionRowViewPrefab();
        GameObject GetWeaponSelectionPanelPrefab();
        GameObject GetSlotForSelectWeaponPrefab();

        SpaceShipConfigSO GetSpaceShipConfig(SpaceShipType spaceShipType);
        WeaponConfigSO GetWeaponConfig(WeaponType weaponType);
        IEnumerable<WeaponConfigSO> GetWeaponConfigs();
        GameObject GetSpaceShipSelectionPanelPrefab();
        GameObject GetSpaceShipDescriptionRowViewPrefab();
        IEnumerable<SpaceShipConfigSO> GetSpaceShipsConfigs();
    }
}
