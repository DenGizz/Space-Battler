using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.Factories;
using Assets.Scripts.Units;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class SpaceShipFactory : ISpaceShipFactory
    {
        IAssetsProvider _assetsProvider;
        ISpaceShipRegistry _spaceShipRegistry;
        ICombatAIRegistry _combatAIRegistry;
        ISpaceShipsGameObjectRegistry _spaceShipsGameObjectRegistry;

        [Inject]
        public SpaceShipFactory(IAssetsProvider assetsProvider, ISpaceShipRegistry spaceShipRegistry, ICombatAIRegistry combatAIRegistry, ISpaceShipsGameObjectRegistry spaceShipsGameObjectRegistry)
        {
            _assetsProvider = assetsProvider;
            _spaceShipRegistry = spaceShipRegistry;
            _combatAIRegistry = combatAIRegistry;
            _spaceShipsGameObjectRegistry = spaceShipsGameObjectRegistry;
        }

        public ISpaceShip CreatePlayerSpaceShip(Vector3 position)
        {
            (GameObject spaceShipGO, ISpaceShip spaceShip) = CreateSpaceShip(_assetsProvider.GetSpaceShipPrefab());

            SetSpaceShipColor(spaceShipGO, Color.green);
            PlaceSpaceShip(spaceShipGO, position, -90);
            spaceShip.AddWeapon(spaceShipGO.GetComponent<IWeapon>());

            return spaceShip;
        }

        public ISpaceShip CreateEnemySpaceShip(Vector3 position)
        {
           (GameObject spaceShipGO, ISpaceShip spaceShip) = CreateSpaceShip(_assetsProvider.GetSpaceShipPrefab());

            SetSpaceShipColor(spaceShipGO, Color.red);
            PlaceSpaceShip(spaceShipGO, position, 90);
            spaceShip.AddWeapon(spaceShipGO.GetComponent<IWeapon>());

            return spaceShip;
        }

        private (GameObject gameObject, ISpaceShip spaceShip) CreateSpaceShip(GameObject prefab)
        {
            GameObject gameObject = GameObject.Instantiate(prefab);
            ISpaceShip spaceShip = gameObject.GetComponent<ISpaceShip>();

            ICombatAI combatAI = gameObject.GetComponent<ICombatAI>();

            _spaceShipRegistry.EnemySpaceShip = spaceShip;
            _combatAIRegistry.RegisterAI(spaceShip, combatAI);

            _spaceShipsGameObjectRegistry.RegisterGameObject(spaceShip, gameObject);

            return (gameObject, spaceShip);
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