using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using Assets.Scripts.Entities.Projectiles;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IAssetsProvider
    {
        GameObject GetSpaceShipPrefab(SpaceShipType spaceShipType);
        GameObject GetWeaponPrefab(WeaponType weaponType);

        GameObject GetBattleUIPrefab();
        GameObject GetMainMenuUIPrefab();
        GameObject GetPauseResumeUIPrefab();
        GameObject GetWeaponDescriptionRowViewPrefab();
        GameObject GetWeaponSelectionPanelPrefab();
        GameObject GetSpaceShipSelectionPanelPrefab();
        GameObject GetSpaceShipDescriptionRowViewPrefab();

        IEnumerable<WeaponDescriptor> GetWeaponDescriptors();
        IEnumerable<SpaceShipDescriptor> GetSpaceShipsDescriptors();
        IEnumerable<ProjectileDescriptor> GetProjectileDescriptors();
        SpaceShipDescriptor GetSpaceShipDescriptor(SpaceShipType spaceShipType);
        WeaponDescriptor GetWeaponDescriptor(WeaponType weaponType);
        ProjectileDescriptor GetProjectileDescriptor(ProjectileType projectileType);
        Object GetWinnerUIPrefab();
    }
}
