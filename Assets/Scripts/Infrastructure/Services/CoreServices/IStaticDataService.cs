using Assets.Scripts.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using UnityEngine;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShip;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IStaticDataService
    {
        Sprite GetSpriteFor(SpaceShipType spaceShipType);
        Sprite GetSpriteFor(WeaponType weaponType);
        IEnumerable<WeaponConfigSO> GetWeaponConfigs();
        IEnumerable<SpaceShipConfigSO> GetSpaceShipsConfigs();
        SpaceShipConfig GetSpaceShipConfig(SpaceShipType spaceShipType);
    }
}
