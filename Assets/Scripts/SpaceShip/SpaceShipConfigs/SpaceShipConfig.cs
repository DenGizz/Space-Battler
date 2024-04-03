using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SpaceShip
{
    public class SpaceShipConfig
    {
        public float MaxHP { get; }
        public int WeaponSlots { get; }

        public SpaceShipConfig(float maxHP, int weaponSlots)
        {
            MaxHP = maxHP;
            WeaponSlots = weaponSlots;
        }
    }
}
