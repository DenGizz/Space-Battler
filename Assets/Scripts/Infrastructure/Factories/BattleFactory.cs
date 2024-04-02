using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class BattleFactory : IBattleFactory
    {
        ICombatAIRegistry _combatAIRegistry;

        public BattleFactory(ICombatAIRegistry combatAIRegistry)
        {
            _combatAIRegistry = combatAIRegistry;
        }

        public BattleData CreateBattleForSpaceShips(ISpaceShip player, ISpaceShip enemy)
        {
           return new BattleData(player, enemy, _combatAIRegistry.GetAI(player), _combatAIRegistry.GetAI(enemy));
        }
    }
}
