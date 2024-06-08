using Assets.Scripts.AI;
using Assets.Scripts.AI.AiStrategies;
using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.Ai
{
    public class AiAssignService : IAiAssignService
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IAiStrategyFactory _aiStrategyFactory;
        private readonly ISpaceShipAiRegistry _spaceShipAiRegistry;
        private readonly IInstantiator _instantiator;

        public AiAssignService(IGameObjectRegistry gameObjectRegistry, IAiStrategyFactory aiStrategyFactory, ISpaceShipAiRegistry spaceShipAiRegistry)
        {
            _gameObjectRegistry = gameObjectRegistry;
            _aiStrategyFactory = aiStrategyFactory;
            _spaceShipAiRegistry = spaceShipAiRegistry;
        }

        public void AssignTeamBattleAi(ISpaceShip spaceShip, BattleTeam team, BattleTeam opponentTeam)
        {
            GameObject spaceShipGameObject = _gameObjectRegistry.GetSpaceShipGameObject(spaceShip);

            TeamBattleSpaceShipAiBehaviour aiBehaviour = 
                _instantiator.InstantiateComponent<TeamBattleSpaceShipAiBehaviour>(spaceShipGameObject);

            ISelectTargetStrategy selectTargetStrategy = _aiStrategyFactory.CreateSelectTargetStrategy();
            IUpdateTargetStrategy updateTargetStrategy = _aiStrategyFactory.CreateUpdateTargetStrategy();

            aiBehaviour.Setup(team, opponentTeam, selectTargetStrategy, updateTargetStrategy);

            _spaceShipAiRegistry.RegisterAi(spaceShip, aiBehaviour);
        }
    }
}
