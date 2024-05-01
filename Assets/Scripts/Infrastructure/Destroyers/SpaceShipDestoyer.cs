﻿using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShips;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Destroyers
{
    public class SpaceShipDestoyer : ISpaceShipDestroyer
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly ICombatAiRegistry _combatAIRegistry;
        private readonly IBattleTickService _battleTickService;

        [Inject]
        public SpaceShipDestoyer(IGameObjectRegistry gameObjectRegistry, ICombatAiRegistry combatAIRegistry, IBattleTickService battleTickService)
        {
            _gameObjectRegistry = gameObjectRegistry;
            _combatAIRegistry = combatAIRegistry;
            _battleTickService = battleTickService;
        }

        public void Destroy(ISpaceShip spaceShip)
        {
            GameObject gameObject = _gameObjectRegistry.GetSpaceShipGameObject(spaceShip);

            ITickable[] tickableBehaviours = gameObject.GetComponents<ITickable>();
            foreach (var tickableBehaviour in tickableBehaviours)
                _battleTickService.RemoveTickable(tickableBehaviour);

            _gameObjectRegistry.UnRegisterGameObject(gameObject);
            _combatAIRegistry.UnRegisterAi(spaceShip);
            Object.Destroy(gameObject);
        }
    }
}