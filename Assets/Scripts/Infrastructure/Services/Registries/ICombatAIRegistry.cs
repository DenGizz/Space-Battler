﻿using System.Collections.Generic;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.SpaceShips;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public interface ICombatAiRegistry
    {
        public IEnumerable<ICombatAI> CombatAIs { get; }
        public ICombatAI GetAI(ISpaceShip spaceShip);
        public void RegisterAI(ISpaceShip spaceShip, ICombatAI combatUnitAI);
        public void UnregisterAI(ISpaceShip spaceShip);
    }
}
