using Assets.Scripts.Units;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public interface ISpaceShipRegistry
    {
        public ISpaceShip PlayerSpaceShip { get; set; }
        public ISpaceShip EnemySpaceShip { get; set; }
    }
}