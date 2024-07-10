using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Entities.Projectiles
{
    public interface IProjectile
    {
        ProjectileData Data { get; }
        ProjectileConfig Config { get; }
        
        void Launch(ISpaceShip target, float damage);
        void Reset();
    }
}
