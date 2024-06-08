using System.Collections.Generic;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Infrastructure.Gameplay.Registries
{
    public interface ISpaceShipAiRegistry
    {
        public IEnumerable<ICombatAi> CombatAIs { get; }
        public ICombatAi GetAi(ISpaceShip spaceShip);
        public void RegisterAi(ISpaceShip spaceShip, ICombatAi combatAi);
        public void UnRegisterAi(ISpaceShip spaceShip);
    }
}
