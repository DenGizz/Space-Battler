using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.GameObjectDestroyers
{
    public class SpaceShipDestoyer : ISpaceShipDestroyer
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IGameplayTickService _gameplayTickService;
        private readonly ISpaceShipRegistry _spaceShipRegistry;

        [Inject]
        public SpaceShipDestoyer(IGameObjectRegistry gameObjectRegistry, IGameplayTickService gameplayTickService, ISpaceShipRegistry spaceShipRegistry)
        {
            _gameObjectRegistry = gameObjectRegistry;
            _gameplayTickService = gameplayTickService;
            _spaceShipRegistry = spaceShipRegistry;
        }

        public void Destroy(ISpaceShip spaceShip)
        {
            GameObject gameObject = _gameObjectRegistry.GetSpaceShipGameObject(spaceShip);

            ITickable[] tickables = gameObject.GetComponents<ITickable>();
            _gameplayTickService.RemoveTickable(tickables);

            _spaceShipRegistry.Unregister(spaceShip);
            _gameObjectRegistry.UnRegisterGameObject(gameObject);
            Object.Destroy(gameObject);
        }
    }
}
