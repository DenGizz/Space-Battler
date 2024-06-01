using System.Collections.Generic;
using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
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