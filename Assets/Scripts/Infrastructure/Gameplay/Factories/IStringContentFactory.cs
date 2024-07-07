using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Gameplay.Factories
{
    public interface IStringContentFactory
    {
        string CreateStringByKey(string stringKey);

        string CreateWeaponDescription(WeaponType type);
        string CreateWeaponName(WeaponType type);

        string CreateSpaceShipDescription(SpaceShipType type);
        string CreateSpaceShipName(SpaceShipType type);
    }
}
