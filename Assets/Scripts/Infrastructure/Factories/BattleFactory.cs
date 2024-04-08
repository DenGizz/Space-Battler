using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.AI.UnitsAI;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class BattleFactory : IBattleFactory
    {
        private readonly ICombatAiRegistry _combatAiRegistry;

        public BattleFactory(ICombatAiRegistry combatAiRegistry)
        {
            _combatAiRegistry = combatAiRegistry;
        }

        public Battle.Battle CreateBattle(ISpaceShip playerSpaceShip, ISpaceShip enemySpaceShip)
        {
            ICombatAI playerAi = _combatAiRegistry.GetAI(playerSpaceShip);
            ICombatAI enemyAi = _combatAiRegistry.GetAI(enemySpaceShip);

            return new Battle.Battle(playerSpaceShip, enemySpaceShip, playerAi, enemyAi);
        }
    }
}
