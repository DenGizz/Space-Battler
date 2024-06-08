using System.Collections.Generic;
using Assets.Scripts.AI;
using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Infrastructure.Gameplay.Registries
{
    public interface ISpaceShipAiRegistry
    {
        public IEnumerable<ISpaceSipAi> SpaceShipAis { get; }
        public ISpaceSipAi GetAi(ISpaceShip spaceShip);
        public void RegisterAi(ISpaceShip spaceShip, ISpaceSipAi combatAi);
        public void UnRegisterAi(ISpaceShip spaceShip);
    }
}
