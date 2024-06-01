using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Entities.SpaceShips;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
{
    public class FitSpaceShipsOnScreenService : IFitSpaceShipsOnScreenService
    {
        private const float SideOffset = 100;
        private const float VerticalOffset = 300;

        public void FitSpaceShipsOnScreen(IEnumerable<ISpaceShip> spaceShips, IFitSpaceShipsOnScreenService.ScreenSide screenSide)
        {
            float zRotation = screenSide switch
            {
                IFitSpaceShipsOnScreenService.ScreenSide.Left => -90,
                IFitSpaceShipsOnScreenService.ScreenSide.Right => 90,
                _ => throw new ArgumentOutOfRangeException(nameof(screenSide), screenSide, null)
            };

            Vector2 sideCentre = screenSide switch
            {
                IFitSpaceShipsOnScreenService.ScreenSide.Left => new Vector2(Screen.width / 4 - SideOffset, Screen.height / 2),
                IFitSpaceShipsOnScreenService.ScreenSide.Right => new Vector2(Screen.width / 4 * 3 + SideOffset, Screen.height / 2),
                _ => throw new ArgumentOutOfRangeException(nameof(screenSide), screenSide, null)
            };

            Vector2[] verticalPositions = new Vector2[spaceShips.Count()];

            for (int i = 0; i < spaceShips.Count(); i++)
                verticalPositions[i] = new Vector2(sideCentre.x, sideCentre.y + (i - spaceShips.Count() / 2) * VerticalOffset);

            for (int i = 0; i < spaceShips.Count(); i++)
            {
                Vector3 position = Camera.main.ScreenToWorldPoint(verticalPositions[i]); //TODO: Use careta provider
                position = new Vector3(position.x, position.y, 0);
                spaceShips.ElementAt(i).SetPosition(position);
                spaceShips.ElementAt(i).SetRotation(zRotation);
            }
        }
    }
}