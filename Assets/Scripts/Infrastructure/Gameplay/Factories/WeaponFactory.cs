using Assets.Scripts.Entities.Weapons;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Core.Services.AssetProviders;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IGameplayTickService _gameplayTickService;
        private readonly IInstantiator _instantiator;

        public WeaponFactory(IAssetsProvider assetsProvider, IGameObjectRegistry gameObjectRegistry, IGameplayTickService gameplayTickService, IInstantiator instantiator)
        {
            _assetsProvider = assetsProvider;
            _gameObjectRegistry = gameObjectRegistry;
            _gameplayTickService = gameplayTickService;
            _instantiator = instantiator;
        }

        public IWeapon CreateWeapon(WeaponType weaponType, Vector3 position, float zRotation)
        {
            GameObject weaponPrefab = _assetsProvider.GetWeaponPrefab(weaponType);
            GameObject weaponGameObject = _instantiator.InstantiatePrefab(weaponPrefab, position, Quaternion.Euler(0, 0, zRotation), null);
            WeaponBehaviour weaponBehaviour = weaponGameObject.GetComponentInChildren<WeaponBehaviour>();

            ITickable[] tickables = weaponGameObject.GetComponents<ITickable>();
            _gameplayTickService.AddTickable(tickables);


            IWeapon weapon = weaponBehaviour;
            _gameObjectRegistry.RegisterWeaponGameObject(weapon, weaponGameObject);
            return weapon;
        }
    }
}
