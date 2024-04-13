using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.Weapons;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Destroyers
{
    public class WeaponDestroyer : IWeaponDestroyer
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IBattleTickService _battleTickService;

        [Inject]
        public WeaponDestroyer(IGameObjectRegistry gameObjectRegistry, IBattleTickService battleTickService)
        {
            _gameObjectRegistry = gameObjectRegistry;
            _battleTickService = battleTickService;
        }

        public void Destroy(IWeapon weapon)
        {
            GameObject gameObject = _gameObjectRegistry.GetWeaponGameObject(weapon);

            ITickable[] tickableBehaviours = gameObject.GetComponents<ITickable>();
            foreach (var tickableBehaviour in tickableBehaviours)
                _battleTickService.RemoveTickable(tickableBehaviour);

            _gameObjectRegistry.UnRegisterGameObject(gameObject);
            Object.Destroy(gameObject);
        }
    }
}
