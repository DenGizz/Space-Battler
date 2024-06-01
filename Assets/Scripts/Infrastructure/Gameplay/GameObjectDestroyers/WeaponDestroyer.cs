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

            _battleTickService.UnRegisterGameObjectTickables(gameObject);

            _gameObjectRegistry.UnRegisterGameObject(gameObject);
            Object.Destroy(gameObject);
        }
    }
}
