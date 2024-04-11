using System.Collections.Generic;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.SpaceShips;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public interface ICombatAiRegistry
    {
        public IEnumerable<ICombatAi> CombatAIs { get; }
        public ICombatAi GetAi(ISpaceShip spaceShip);
        public void RegisterAi(ISpaceShip spaceShip, ICombatAi combatAi);
        public void UnRegisterAi(ISpaceShip spaceShip);
    }
}
