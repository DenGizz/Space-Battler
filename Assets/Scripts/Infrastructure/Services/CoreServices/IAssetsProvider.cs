using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IAssetsProvider
    {
        GameObject GetBattleUIPrefab();
        GameObject GetSpaceShipPrefab();
    }
}
