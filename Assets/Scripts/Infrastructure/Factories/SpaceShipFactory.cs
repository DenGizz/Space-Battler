using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services;
using System.Collections;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShip;
using UnityEngine;
using Zenject;
using Assets.Scripts.SpaceShip.SpaceShipComponents;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class SpaceShipFactory : ISpaceShipFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly ICombatAiRegistry _combatAIRegistry;
        private readonly IGameObjectRegistry _gameObjectRegistry;

        [Inject]
        public SpaceShipFactory(IAssetsProvider assetsProvider, 
            ICombatAiRegistry combatAIRegistry, IGameObjectRegistry gameObjectRegistry)
        {
            _assetsProvider = assetsProvider;
            _combatAIRegistry = combatAIRegistry;
            _gameObjectRegistry = gameObjectRegistry;
        }

        public ISpaceShip CreateSpaceShip(SpaceShipType type, Vector3 position, float zRotation, Color color)
        {
            GameObject prefab = _assetsProvider.GetSpaceShipPrefab(type);
            GameObject gameObject = GameObject.Instantiate(prefab);
            SpaceShipComponent spaceShipComponent = gameObject.GetComponent<SpaceShipComponent>();

            PlaceSpaceShip(gameObject, position, zRotation);

            ISpaceShip spaceShip = spaceShipComponent;
            ICombatAI combatAI = gameObject.GetComponent<ICombatAI>();

            _combatAIRegistry.RegisterAI(spaceShip, combatAI);
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