using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices.AssetProviders
{
    public interface IUiAssetsProvider
    {
        GameObject GetMainMenuUiPrefab();
        GameObject GetSandboxModeUiPrefab();
        GameObject GetSpaceShipHealthViewPrefab();
        GameObject GetWindowPrefab();
    }
}
