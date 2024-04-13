using Assets.Scripts.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Destroyers
{
    public interface ISpaceShipDestroyer
    {
        void Destroy(ISpaceShip spaceShip);
    }
}
