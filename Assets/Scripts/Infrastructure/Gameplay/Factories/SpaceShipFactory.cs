using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Core.Services.AssetProviders;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.Factories
{
    public class SpaceShipFactory : ISpaceShipFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IRootTransformsProvider _rootTransformsProvider;
        private readonly ISpaceShipRegistry _spaceShipRegistry;
        private readonly IGameplayTickService _gameplayTickService;
        private readonly IInstantiator _instantiator;

        [Inject]
        public SpaceShipFactory(IAssetsProvider assetsProvider, 
            IGameObjectRegistry gameObjectRegistry, 
            IRootTransformsProvider rootTransformsProvider,
            IGameplayTickService gameplayTickService, IInstantiator instantiator, ISpaceShipRegistry spaceShipRegistry)
        {
            _assetsProvider = assetsProvider;
            _gameObjectRegistry = gameObjectRegistry;
            _rootTransformsProvider = rootTransformsProvider;
            _gameplayTickService = gameplayTickService;//TODO: Bring battle tick service registration to another place
            _instantiator = instantiator;
            _spaceShipRegistry = spaceShipRegistry;
        }

        public ISpaceShip CreateSpaceShip(SpaceShipType type, Vector3 position = default, float zRotation = 0)//TODO: Pass SpaceShipData. No parameters
        {
            GameObject prefab = _assetsProvider.GetSpaceShipPrefab(type);
            GameObject gameObject = _instantiator.InstantiatePrefab(prefab, _rootTransformsProvider.SpaceShipsRoot);
            var spaceShipComponent = gameObject.GetComponent<SpaceShipBehaviour>();
            SpaceShipData spaceShipData = new SpaceShipData(position);
            spaceShipComponent.SetData(spaceShipData);

            ITickable[] tickables = gameObject.GetComponents<ITickable>();
            _gameplayTickService.AddTickable(tickables);

            PlaceSpaceShip(gameObject, position, zRotation);

            _spaceShipRegistry.Register(spaceShipComponent);

            ISpaceShip spaceShip = spaceShipComponent;

            _gameObjectRegistry.RegisterSpaceShipGameObject(spaceShip, gameObject);

            return spaceShip;
        }

        private void PlaceSpaceShip(GameObject go, Vector3 position, float zRotation)
        {
            go.transform.position = position;
            go.transform.rotation = Quaternion.Euler(0, 0, zRotation);
        }
    }
}