﻿using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Battles;
using Assets.Scripts.SpaceShips;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class BattleFactory : IBattleFactory
    {
        private readonly ICombatAiRegistry _combatAiRegistry;

        public BattleFactory(ICombatAiRegistry combatAiRegistry)
        {
            _combatAiRegistry = combatAiRegistry;
        }

        public Battle CreateBattle(ISpaceShip playerSpaceShip, ISpaceShip enemySpaceShip)
        {
            ICombatAi playerAi = _combatAiRegistry.GetAi(playerSpaceShip);
            ICombatAi enemyAi = _combatAiRegistry.GetAi(enemySpaceShip);

            return new Battle(playerSpaceShip, enemySpaceShip, playerAi, enemyAi);
        }
    }
}