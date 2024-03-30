using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.Factories;
using Assets.Scripts.Units;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class SpaceShipFactory : ISpaceShipFactory
    {
        IAssetsProvider _assetsProvider;
        ISpaceShipRegistry _spaceShipRegistry;

        public SpaceShipFactory(IAssetsProvider assetsProvider, ISpaceShipRegistry spaceShipRegistry)
        {
            _assetsProvider = assetsProvider;
            _spaceShipRegistry = spaceShipRegistry;
        }

        public ISpaceShip CreatePlayerSpaceShip(Vector3 position)
        {
            GameObject gameObject = GameObject.Instantiate(_assetsProvider.GetSpaceShipPrefab());
            ISpaceShip spaceShip = gameObject.GetComponent<ISpaceShip>();

            SetSpaceShipColor(gameObject, Color.green);
            PlaceSpaceShip(gameObject, position, -90);

            _spaceShipRegistry.PlayerSpaceShip = spaceShip;
            return spaceShip;
        }

        public ISpaceShip CreateEnemySpaceShip(Vector3 position)
        {
            GameObject gameObject = GameObject.Instantiate(_assetsProvider.GetSpaceShipPrefab());
            ISpaceShip spaceShip = gameObject.GetComponent<ISpaceShip>();

            SetSpaceShipColor(gameObject, Color.red);
            PlaceSpaceShip(gameObject, position, 90);

            _spaceShipRegistry.EnemySpaceShip = spaceShip;
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