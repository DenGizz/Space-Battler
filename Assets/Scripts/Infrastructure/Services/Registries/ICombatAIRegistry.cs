using System.Collections.Generic;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.SpaceShips;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public interface ICombatAiRegistry
    {
        public IEnumerable<ICombatAi> CombatAIs { get; }
        public ICombatAi GetAI(ISpaceShip spaceShip);
        public void RegisterAI(ISpaceShip spaceShip, ICombatAi combatUnitAI);
        public void UnregisterAI(ISpaceShip spaceShip);
    }
}
