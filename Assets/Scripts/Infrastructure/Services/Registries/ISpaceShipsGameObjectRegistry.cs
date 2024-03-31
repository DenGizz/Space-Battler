using Assets.Scripts.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface ISpaceShipsGameObjectRegistry
    {
        void RegisterGameObject(ISpaceShip spaceShip, GameObject gameObject);
        void UnregisterGameObject(GameObject gameObject);

        GameObject GetSpaceShipGameObject(ISpaceShip spaceShip);
    }
}
