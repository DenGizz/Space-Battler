using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.Weapons.WeaponConfigs;
using System.Collections.Generic;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
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
        GameObject GetSpaceShipSelectionPanelPrefab();
        GameObject GetSpaceShipDescriptionRowViewPrefab();

        IEnumerable<WeaponDescriptor> GetWeaponConfigs();
        IEnumerable<SpaceShipDescriptor> GetSpaceShipsConfigs();
        SpaceShipDescriptor GetSpaceShipConfig(SpaceShipType spaceShipType);
        WeaponDescriptor GetWeaponConfig(WeaponType weaponType);
    }
}
