using System.Collections.Generic;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.SpaceShips;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public class CombatAIRegistry : ICombatAiRegistry
    {
        public IEnumerable<ICombatAi> CombatAIs => _combatAis.Values;

        private readonly Dictionary<ISpaceShip, ICombatAi> _combatAis = new Dictionary<ISpaceShip, ICombatAi>();

        public ICombatAi GetAi(ISpaceShip spaceShip)
        {
            return _combatAis.ContainsKey(spaceShip) ? _combatAis[spaceShip] : null;
        }

        public void RegisterAi(ISpaceShip spaceShip, ICombatAi combatAi)
        {     
            if (_combatAis.ContainsKey(spaceShip))
            {
                _combatAis[spaceShip] = combatAi;
            }
            else
            {
                _combatAis.Add(spaceShip, combatAi);
            }
        }

        public void UnRegisterAi(ISpaceShip spaceShip)
        {
            
            if (_combatAis.ContainsKey(spaceShip))
            {
                _combatAis.Remove(spaceShip);
            }
        }
    }
}
