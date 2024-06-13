using Assets.Scripts.AI;
using Assets.Scripts.AI.AiStrategies;
using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Ai
{
    public class AiAssignService : IAiAssignService
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IGameplayTickService _gameplayTickService;
        private readonly IAiStrategyFactory _aiStrategyFactory;
        private readonly IInstantiator _instantiator;

        public AiAssignService(IInstantiator instantiator, IAiStrategyFactory aiStrategyFactory, IGameObjectRegistry gameObjectRegistry, IGameplayTickService gameplayTickService)
        {
            _instantiator = instantiator;
             _aiStrategyFactory = aiStrategyFactory;
            _gameObjectRegistry = gameObjectRegistry;
            _gameplayTickService = gameplayTickService;
        }

        public void AssignTeamMemberAiToSpaceShip(ISpaceShip spaceShip, BattleTeam team, BattleTeam opponentTeam)
        {
            GameObject spaceShipGameObejct = _gameObjectRegistry.GetSpaceShipGameObject(spaceShip);

            

            TeamMemberSpaceShipAiBehaviour aiBehaviour =
                _instantiator.InstantiateComponent<TeamMemberSpaceShipAiBehaviour>(spaceShipGameObejct);

            _gameplayTickService.AddTickable(aiBehaviour);

            aiBehaviour.Construct(team, opponentTeam);
            aiBehaviour.SelectTargetStrategy = new SelectRandomTargetStrategy();
            aiBehaviour.UpdateTargetStrategy = _aiStrategyFactory.CreateUpdateTargetStrategy();
        }
    }
}
