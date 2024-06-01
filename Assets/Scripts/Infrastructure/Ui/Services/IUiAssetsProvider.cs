using UnityEngine;

namespace Assets.Scripts.Infrastructure.Ui.Services
{
    public interface IUiAssetsProvider
    {
        GameObject GetMainMenuUiPrefab();
        GameObject GetPauseBattleHUDPrefab();
        GameObject GetSandboxModeUiPrefab();
        GameObject GetSpaceShipHealthViewPrefab();
        GameObject GetSpaceShipTypeRowPrefab();
        GameObject GetUiGridPrefab();
        GameObject GetWeaponTypeRowPrefab();
        GameObject GetWeaponTypeSlotPrefab();
        GameObject GetWindowPrefab();
    }
}
