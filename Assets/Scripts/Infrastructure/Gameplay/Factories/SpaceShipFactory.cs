using Assets.Scripts.AI.UnitsAI;
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
        private readonly ICombatAiRegistry _combatAiRegistry;
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IRootTransformsProvider _rootTransformsProvider;
        private readonly IBattleTickService _battleTickService;

        [Inject]
        public SpaceShipFactory(IAssetsProvider assetsProvider, 
            ICombatAiRegistry combatAiRegistry, IGameObjectRegistry gameObjectRegistry, IRootTransformsProvider rootTransformsProvider, IBattleTickService battleTickService)
        {
            _assetsProvider = assetsProvider;
            _combatAiRegistry = combatAiRegistry;
            _gameObjectRegistry = gameObjectRegistry;
            _rootTransformsProvider = rootTransformsProvider;
            _battleTickService = battleTickService;
        }

        public ISpaceShip CreateSpaceShip(SpaceShipType type, Vector3 position, float zRotation)//TODO: Pass SpaceShipData. No parameters
        {
            GameObject prefab = _assetsProvider.GetSpaceShipPrefab(type);
            GameObject gameObject = Object.Instantiate(prefab, _rootTransformsProvider.SpaceShipsRoot);
            var spaceShipComponent = gameObject.GetComponent<SpaceShipBehaviour>();
            SpaceShipData spaceShipData = new SpaceShipData(position);
            spaceShipComponent.Construct(spaceShipData);

            _battleTickService.RegisterGameObjectTickables(gameObject);

            PlaceSpaceShip(gameObject, position, zRotation);

            ISpaceShip spaceShip = spaceShipComponent;
            ICombatAi combatAi = gameObject.GetComponent<ICombatAi>();

            _combatAiRegistry.RegisterAi(spaceShip, combatAi);
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