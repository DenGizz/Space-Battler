using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SpaceShip
{
    public class SpaceShipData
    {
        public Vector3 Position { get; set; }
        public IEnumerable<IWeapon> Weapons { get; set; }
        public float Health { get; set; }
        public float MaxHealth { get; set; }
    }
}