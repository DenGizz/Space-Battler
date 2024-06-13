using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Gameplay.Registries
{
    public class SpaceShipRegistry : ISpaceShipRegistry
    {
        public IEnumerable<ISpaceShip> SpaceShips => _spaceShips;

        public event Action<ISpaceShip> OnSpaceShipRegistered;
        public event Action<ISpaceShip> OnSpaceShipUnregistered;

        private readonly List<ISpaceShip> _spaceShips = new List<ISpaceShip>();

        public void Register(ISpaceShip spaceShip)
        {
            _spaceShips.Add(spaceShip);
            OnSpaceShipRegistered?.Invoke(spaceShip);
        }

        public void Unregister(ISpaceShip spaceShip)
        {
            _spaceShips.Remove(spaceShip);
            OnSpaceShipUnregistered?.Invoke(spaceShip);
        }
    }
}
