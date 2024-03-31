using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface ICombatAIRegistry
    {
        public IEnumerable<ICombatAI> CombatAIs { get; }
        public ICombatAI GetAI(ISpaceShip spaceShip);
        public void RegisterAI(ISpaceShip spaceShip, ICombatAI combatUnitAI);
        public void UnregisterAI(ISpaceShip spaceShip);
    }
}
