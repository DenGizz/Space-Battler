using Assets.Scripts.Entities.Weapons;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.GameObjectDestroyers
{
    public class WeaponDestroyer : IWeaponDestroyer
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IGameplayTickService _gameplayTickService;

        [Inject]
        public WeaponDestroyer(IGameObjectRegistry gameObjectRegistry, IGameplayTickService gameplayTickService)
        {
            _gameObjectRegistry = gameObjectRegistry;
            _gameplayTickService = gameplayTickService;
        }

        public void Destroy(IWeapon weapon)
        {
            GameObject gameObject = _gameObjectRegistry.GetWeaponGameObject(weapon);

            ITickable[] tickables = gameObject.GetComponents<ITickable>();
            _gameplayTickService.RemoveTickable(tickables);

            _gameObjectRegistry.UnRegisterGameObject(gameObject);
            Object.Destroy(gameObject);
        }
    }
}
