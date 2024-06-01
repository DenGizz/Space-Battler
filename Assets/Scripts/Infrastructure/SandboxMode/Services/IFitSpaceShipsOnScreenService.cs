using Assets.Scripts.Entities.SpaceShips;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IFitSpaceShipsOnScreenService
    {
        public enum ScreenSide
        {
            Left,
            Right
        }

        public void FitSpaceShipsOnScreen(IEnumerable<ISpaceShip> spaceShips, ScreenSide screenSide);
    }
}