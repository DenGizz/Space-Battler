using System.Collections;
using Assets.Scripts.Units;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factories
{
    public interface ISpaceShipFactory
    {
        ISpaceShip CreatePlayerSpaceShip();
        ISpaceShip CreateEnemySpaceShip();
    }
}