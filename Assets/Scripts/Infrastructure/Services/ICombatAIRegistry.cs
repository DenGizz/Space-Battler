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
        public ICombatAI GetAI(ICombatUnit combatUnit);
        public void RegisterAI(ICombatUnit combatUnit, ICombatAI combatUnitAI);
        public void UnregisterAI(ICombatUnit combatUnit);
    }
}
