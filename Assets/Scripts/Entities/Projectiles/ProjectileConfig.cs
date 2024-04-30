using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Projectiles
{
    public class ProjectileConfig
    {
        public ProjectileType Type { get; }
        public float Speed { get; }

        public ProjectileConfig(ProjectileType type, float speed)
        {
            Type = type;
            Speed = speed;
        }
    }
}
