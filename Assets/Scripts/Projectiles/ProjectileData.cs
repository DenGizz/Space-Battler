using Assets.Scripts.SpaceShips;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    public class ProjectileData
    {
        public ISpaceShip Target { get; set; }
        public Vector3 Position { get; set; }
        public float Damage { get; set; }
        public bool IsReachedTarget { get; set; }
        public bool IsLaunched { get; set; }

        public ProjectileData(Vector3 position)
        {
            Position = position;
        }
    }
}