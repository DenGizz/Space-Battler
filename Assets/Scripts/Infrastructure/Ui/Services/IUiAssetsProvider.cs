using UnityEngine;

namespace Assets.Scripts.Infrastructure.Ui.Services
{
    public interface IUiAssetsProvider
    {
        GameObject GetMainMenuUiPrefab();
        GameObject GetPauseBattleHUDPrefab();
        GameObject GetPopoutMessagePrefab();
        GameObject GetPopoutMessagesOverlayPrefab();
        GameObject GetSandboxModeUiPrefab();
        GameObject GetSpaceShipHealthViewPrefab();
        GameObject GetSpaceShipSetupEditPrefab();
        GameObject GetSpaceShipSetupRowPrefab();
        GameObject GetSpaceShipTypeRowPrefab();
        GameObject GetUiGridPrefab();
        GameObject GetWeaponTypeRowPrefab();
        GameObject GetWeaponTypeSlotPrefab();
        GameObject GetWindowPrefab();
    }
}
