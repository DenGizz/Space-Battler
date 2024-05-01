using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IRandomSetupService
    {
        void RandomizeSpaceShipSetup(SpaceShipSetup spaceShipSetup);
    }
}
