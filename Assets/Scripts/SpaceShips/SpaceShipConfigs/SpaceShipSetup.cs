﻿using System;
using System.Collections.Generic;
using Assets.Scripts.Weapons.WeaponConfigs;

namespace Assets.Scripts.SpaceShips.SpaceShipConfigs
{
    public class SpaceShipSetup
    {
        public SpaceShipType SpaceShipType { get; set; }
        public List<WeaponType> WeaponTypes { get; }

        public SpaceShipSetup()
        {
            SpaceShipType = SpaceShipType.None;
            WeaponTypes = new List<WeaponType>();
        }

        public SpaceShipSetup(SpaceShipType spaceShipType, IEnumerable<WeaponType> weaponTypes)
        {
            SpaceShipType = spaceShipType;
            WeaponTypes = new List<WeaponType>(weaponTypes);
        }
    }
}
