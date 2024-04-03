using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services;
using System.Collections;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShip;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class SpaceShipFactory : ISpaceShipFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly ISpaceShipRegistry _spaceShipRegistry;
        private readonly ICombatAiRegistry _combatAIRegistry;
        private readonly ISpaceShipsGameObjectRegistry _spaceShipsGameObjectRegistry;

        [Inject]
        public SpaceShipFactory(IAssetsProvider assetsProvider, ISpaceShipRegistry spaceShipRegistry, 
            ICombatAiRegistry combatAIRegistry, ISpaceShipsGameObjectRegistry spaceShipsGameObjectRegistry)
        {
            _assetsProvider = assetsProvider;
            _spaceShipRegistry = spaceShipRegistry;
            _combatAIRegistry = combatAIRegistry;
            _spaceShipsGameObjectRegistry = spaceShipsGameObjectRegistry;
        }

        public ISpaceShip CreateSpaceShip(Vector3 position, float zRotation, Color color)
        {
            GameObject prefab = _assetsProvider.GetSpaceShipPrefab();
            GameObject gameObject = GameObject.Instantiate(prefab);

            SetSpaceShipColor(gameObject, color);
            PlaceSpaceShip(gameObject, position, zRotation);

            ISpaceShip spaceShip = gameObject.GetComponent<ISpaceShip>();
            ICombatAI combatAI = gameObject.GetComponent<ICombatAI>();

            _spaceShipRegistry.EnemySpaceShip = spaceShip;
            _combatAIRegistry.RegisterAI(spaceShip, combatAI);

            _spaceShipsGameObjectRegistry.RegisterGameObject(spaceShip, gameObject);

            return spaceShip;
        }

        private void SetSpaceShipColor(GameObject go, Color color)
        {
            go.GetComponent<SpriteRenderer>().color = color;
        }

        private void PlaceSpaceShip(GameObject go, Vector3 position, float zRotation)
        {
            go.transform.position = position;
            go.transform.rotation = Quaternion.Euler(0, 0, zRotation);
        }
    }
}