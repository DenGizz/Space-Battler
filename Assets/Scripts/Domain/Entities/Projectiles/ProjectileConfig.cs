namespace Assets.Scripts.Entities.Projectiles
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
