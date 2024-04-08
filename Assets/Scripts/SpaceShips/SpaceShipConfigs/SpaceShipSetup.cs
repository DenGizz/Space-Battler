using System.Collections.Generic;
using Assets.Scripts.Weapons.WeaponConfigs;

namespace Assets.Scripts.SpaceShips.SpaceShipConfigs
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
