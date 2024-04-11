using System.Collections;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface ISpaceShipFromSetupFactory
    {
        ISpaceShip CreateSpaceShipFromSetup(SpaceShipSetup setup, Vector3 position, float zRotation);
    }
}