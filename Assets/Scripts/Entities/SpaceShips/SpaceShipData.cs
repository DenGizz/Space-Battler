using Assets.Scripts.Entities.Weapons;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entities.SpaceShips
{
    public class SpaceShipData
    {
        public Vector3 Position { get; set; }
        public float ZRotation { get; set; }
        public float HealthPoints { get; set; }
        public bool IsAlive { get; set; }
        public List<IWeapon> Weapons { get; }

        public SpaceShipData(Vector3 position)
        {
            Position = position;
            HealthPoints = 0;
            IsAlive = true;
            Weapons = new List<IWeapon>();
        }
    }
}
