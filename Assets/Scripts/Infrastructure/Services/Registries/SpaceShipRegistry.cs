using Assets.Scripts.Units;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public class SpaceShipRegistry : ISpaceShipRegistry
    {
        public ISpaceShip PlayerSpaceShip { get; set; }
        public ISpaceShip EnemySpaceShip { get; set; }
    }
}
