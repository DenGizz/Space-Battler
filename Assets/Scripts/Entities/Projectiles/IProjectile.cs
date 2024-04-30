using Assets.Scripts.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Projectiles
{
    public interface IProjectile
    {
        ProjectileData Data { get; }
        ProjectileConfig Config { get; }
        
        void Launch(ISpaceShip target, float damage);
        void Reset();
    }
}
