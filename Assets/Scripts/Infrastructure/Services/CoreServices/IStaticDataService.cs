using Assets.Scripts.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IStaticDataService
    {
        Sprite GetSpriteFor(SpaceShipType spaceShipType);
        Sprite GetSpriteFor(WeaponType weaponType);
        IEnumerable<WeaponDescriptor> GetWeaponConfigs();
        IEnumerable<SpaceShipDescriptor> GetSpaceShipsConfigs();
        SpaceShipConfig GetSpaceShipConfig(SpaceShipType spaceShipType);
    }
}
