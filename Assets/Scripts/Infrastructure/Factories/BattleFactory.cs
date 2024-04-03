using Assets.Scripts.Infrastructure.Services.BattleServices;
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
        private readonly IBattleProvider _battleDataProvider;
        private readonly ICombatAiRegistry _combatAiRegistry;

        public BattleFactory(IBattleProvider battleDataProvider, ICombatAiRegistry combatAiRegistry)
        {
            _battleDataProvider = battleDataProvider;
            _combatAiRegistry = combatAiRegistry;
        }

        public Battle.Battle CreateBattle(ISpaceShip playerSpaceShip, ISpaceShip enemySpaceShip)
        {
            Battle.Battle battle = new Battle.Battle(playerSpaceShip, enemySpaceShip, _combatAiRegistry.GetAI(playerSpaceShip), _combatAiRegistry.GetAI(enemySpaceShip)); ;
            _battleDataProvider.CurrentBattle = battle;


            return battle;
        }
    }
}
