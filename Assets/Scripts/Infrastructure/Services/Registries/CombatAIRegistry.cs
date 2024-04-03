using System.Collections.Generic;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.SpaceShip;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public class CombatAIRegistry : ICombatAiRegistry
    {
        public IEnumerable<ICombatAI> CombatAIs => _combatAIs.Values;

        private Dictionary<ISpaceShip, ICombatAI> _combatAIs = new Dictionary<ISpaceShip, ICombatAI>();

        public ICombatAI GetAI(ISpaceShip spaceShip)
        {         
            if (_combatAIs.ContainsKey(spaceShip))
            {
                return _combatAIs[spaceShip];
            }
            else
            {
                return null;
            }
        }

        public void RegisterAI(ISpaceShip spaceShip, ICombatAI combatUnitAI)
        {
           
            if (_combatAIs.ContainsKey(spaceShip))
            {
                _combatAIs[spaceShip] = combatUnitAI;
            }
            else
            {
                _combatAIs.Add(spaceShip, combatUnitAI);
            }
        }

        public void UnregisterAI(ISpaceShip spaceShip)
        {
            
            if (_combatAIs.ContainsKey(spaceShip))
            {
                _combatAIs.Remove(spaceShip);
            }
        }
    }
}
