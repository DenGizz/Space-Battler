using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Gameplay.Registries
{
    public interface ISpaceShipRegistry
    {
        public IEnumerable<ISpaceShip> SpaceShips { get; }

        public event Action<ISpaceShip> OnSpaceShipRegistered;
        public event Action<ISpaceShip> OnSpaceShipUnregistered;

        public void Register(ISpaceShip spaceShip);
        public void Unregister(ISpaceShip spaceShip);
    }
}
