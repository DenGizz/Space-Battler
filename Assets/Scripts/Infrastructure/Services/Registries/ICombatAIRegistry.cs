using System.Collections.Generic;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Units;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public interface ICombatAIRegistry
    {
        public IEnumerable<ICombatAI> CombatAIs { get; }
        public ICombatAI GetAI(ISpaceShip spaceShip);
        public void RegisterAI(ISpaceShip spaceShip, ICombatAI combatUnitAI);
        public void UnregisterAI(ISpaceShip spaceShip);
    }
}
