using System.Collections.Generic;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;

namespace Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs
{
    public class SpaceShipSetup
    {
        public SpaceShipType SpaceShipType { get; set; } = new SpaceShipType();
        public List<WeaponType> WeaponTypes { get; } = new List<WeaponType>();
    }
}
