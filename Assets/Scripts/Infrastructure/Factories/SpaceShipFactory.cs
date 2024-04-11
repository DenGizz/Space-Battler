using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services;
using System.Collections;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class SpaceShipFactory : ISpaceShipFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly ICombatAiRegistry _combatAiRegistry;
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly IRootTransformsProvider _rootTransformsProvider;

        [Inject]
        public SpaceShipFactory(IAssetsProvider assetsProvider, 
            ICombatAiRegistry combatAiRegistry, IGameObjectRegistry gameObjectRegistry, IRootTransformsProvider rootTransformsProvider)
        {
            _assetsProvider = assetsProvider;
            _combatAiRegistry = combatAiRegistry;
            _gameObjectRegistry = gameObjectRegistry;
            _rootTransformsProvider = rootTransformsProvider;
        }

        public ISpaceShip CreateSpaceShip(SpaceShipType type, Vector3 position, float zRotation)
        {
            GameObject prefab = _assetsProvider.GetSpaceShipPrefab(type);
            GameObject gameObject = Object.Instantiate(prefab, _rootTransformsProvider.SpaceShipsRoot);
            var spaceShipComponent = gameObject.GetComponent<SpaceShipBehaviour>();

            PlaceSpaceShip(gameObject, position, zRotation);

            ISpaceShip spaceShip = spaceShipComponent;
            ICombatAi combatAi = gameObject.GetComponent<ICombatAi>();

            _combatAiRegistry.RegisterAI(spaceShip, combatAi);
            _gameObjectRegistry.RegisterGameObject(spaceShip, gameObject);

            return spaceShip;
        }

        private void PlaceSpaceShip(GameObject go, Vector3 position, float zRotation)
        {
            go.transform.position = position;
            go.transform.rotation = Quaternion.Euler(0, 0, zRotation);
        }
    }
}