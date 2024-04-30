using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Infrastructure.Destroyers
{
    public interface ISpaceShipDestroyer
    {
        void Destroy(ISpaceShip spaceShip);
    }
}
