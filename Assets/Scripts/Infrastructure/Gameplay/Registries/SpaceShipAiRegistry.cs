using Assets.Scripts.AI;
using Assets.Scripts.Entities.SpaceShips;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.Gameplay.Registries
{
    public class SpaceShipAiRegistry : ISpaceShipAiRegistry
    {
        public IEnumerable<ISpaceSipAi> SpaceShipAis => _spaceShipAis.Values;

        private readonly Dictionary<ISpaceShip, ISpaceSipAi> _spaceShipAis = new();

        public ISpaceSipAi GetAi(ISpaceShip spaceShip)
        {
            return _spaceShipAis[spaceShip];
        }

        public void RegisterAi(ISpaceShip spaceShip, ISpaceSipAi combatAi)
        {
            _spaceShipAis.Add(spaceShip, combatAi);
        }

        public void UnRegisterAi(ISpaceShip spaceShip)
        {
            _spaceShipAis.Remove(spaceShip);
        }
    }
}
