using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Weapons.WeaponConfigs;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface IStaticDataService
    {
        SpaceShip.SpaceShipConfig GetSpaceShipConfiguration(SpaceShipType corpusType);
        WeaponConfig GetWeaponConfiguration(WeaponType weaponType);
    }
}
