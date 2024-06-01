using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Infrastructure.Gameplay.GameObjectDestroyers
{
    public interface ISpaceShipDestroyer
    {
        void Destroy(ISpaceShip spaceShip);
    }
}
