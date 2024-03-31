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

        [Inject]
        public SpaceShipFactory(IAssetsProvider assetsProvider, ISpaceShipRegistry spaceShipRegistry, ICombatAIRegistry combatAIRegistry)
        {
            _assetsProvider = assetsProvider;
            _spaceShipRegistry = spaceShipRegistry;
            _combatAIRegistry = combatAIRegistry;
        }

        public ISpaceShip CreatePlayerSpaceShip(Vector3 position)
        {
            GameObject gameObject = GameObject.Instantiate(_assetsProvider.GetSpaceShipPrefab());
            ISpaceShip spaceShip = gameObject.GetComponent<ISpaceShip>();

            spaceShip.AddWeapon(gameObject.GetComponent<IWeapon>());

            SetSpaceShipColor(gameObject, Color.green);
            PlaceSpaceShip(gameObject, position, -90);

            ICombatAI combatAI = gameObject.GetComponent<ICombatAI>();

            _spaceShipRegistry.PlayerSpaceShip = spaceShip;
            _combatAIRegistry.RegisterAI(spaceShip, combatAI);

            return spaceShip;
        }

        public ISpaceShip CreateEnemySpaceShip(Vector3 position)
        {
            GameObject gameObject = GameObject.Instantiate(_assetsProvider.GetSpaceShipPrefab());
            ISpaceShip spaceShip = gameObject.GetComponent<ISpaceShip>();

            spaceShip.AddWeapon(gameObject.GetComponent<IWeapon>());

            SetSpaceShipColor(gameObject, Color.red);
            PlaceSpaceShip(gameObject, position, 90);

            ICombatAI combatAI = gameObject.GetComponent<ICombatAI>();

            _spaceShipRegistry.EnemySpaceShip = spaceShip;

            _combatAIRegistry.RegisterAI(spaceShip, combatAI);
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