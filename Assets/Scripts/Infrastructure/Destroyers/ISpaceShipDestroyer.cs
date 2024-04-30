using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Infrastructure.Destroyers
{
    public interface ISpaceShipDestroyer
    {
        void Destroy(ISpaceShip spaceShip);
    }
}
