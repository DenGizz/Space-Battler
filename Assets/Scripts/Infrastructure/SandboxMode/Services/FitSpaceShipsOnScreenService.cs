using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Assets.Scripts.Infrastructure.Services.IFitSpaceShipsOnScreenService;

namespace Assets.Scripts.Infrastructure.Services
{
    public class FitSpaceShipsOnScreenService : IFitSpaceShipsOnScreenService
    {
        private const float SideOffset = 100;
        private const float VerticalOffset = 300;

        public void FitSpaceShipsOnScreen(IEnumerable<ISpaceShip> spaceShips, ScreenSide screenSide)
        {
            float zRotation = screenSide switch
            {
                ScreenSide.Left => -90,
                ScreenSide.Right => 90,
                _ => throw new ArgumentOutOfRangeException(nameof(screenSide), screenSide, null)
            };

            Vector2 sideCentre = screenSide switch
            {
                ScreenSide.Left => new Vector2(Screen.width / 4 - SideOffset, Screen.height / 2),
                ScreenSide.Right => new Vector2(Screen.width / 4 * 3 + SideOffset, Screen.height / 2),
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