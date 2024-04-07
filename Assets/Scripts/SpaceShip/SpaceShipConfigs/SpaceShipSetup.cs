using Assets.Scripts.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SpaceShip.SpaceShipConfigs
{
    public class SpaceShipSetup
    {
        public SpaceShipType? SpaceShipType { get; }
        public IEnumerable<WeaponType> WeaponTypes { get; }

        public SpaceShipSetup(SpaceShipType? spaceShipType, IEnumerable<WeaponType> weaponTypes)
        {
            SpaceShipType = spaceShipType;
            WeaponTypes = weaponTypes;
        }
    }
}
