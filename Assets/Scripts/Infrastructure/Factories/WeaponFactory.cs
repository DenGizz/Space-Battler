using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.Entities.Weapons;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IBattleTickService _battleTickService;
        private readonly IInstantiator _instantiator;

        public WeaponFactory(IAssetsProvider assetsProvider, IGameObjectRegistry gameObjectRegistry, IBattleTickService battleTickService, IInstantiator instantiator)
        {
            _assetsProvider = assetsProvider;
            _gameObjectRegistry = gameObjectRegistry;
            _battleTickService = battleTickService;
            _instantiator = instantiator;
        }

        public IWeapon CreateWeapon(WeaponType weaponType, Vector3 position, float zRotation)
        {
            GameObject weaponPrefab = _assetsProvider.GetWeaponPrefab(weaponType);
            GameObject weaponGameObject = _instantiator.InstantiatePrefab(weaponPrefab, position, Quaternion.Euler(0, 0, zRotation), null);
            WeaponBehaviour weaponBehaviour = weaponGameObject.GetComponentInChildren<WeaponBehaviour>();
            _battleTickService.RegisterGameObjectTickables(weaponGameObject);
            IWeapon weapon = weaponBehaviour;
            _gameObjectRegistry.RegisterWeaponGameObject(weapon, weaponGameObject);
            return weapon;
        }
    }
}
