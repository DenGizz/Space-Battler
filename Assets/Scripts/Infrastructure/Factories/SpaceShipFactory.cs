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

        public SpaceShipFactory(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public ISpaceShip CreatePlayerSpaceShip(Vector3 position)
        {
            GameObject gameObject = GameObject.Instantiate(_assetsProvider.GetSpaceShipPrefab());
            SetSpaceShipColor(gameObject, Color.green);
            gameObject.transform.position = position;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            return gameObject.GetComponent<ISpaceShip>();
        }

        public ISpaceShip CreateEnemySpaceShip(Vector3 position)
        {
            GameObject gameObject = GameObject.Instantiate(_assetsProvider.GetSpaceShipPrefab());
            SetSpaceShipColor(gameObject, Color.red);
            gameObject.transform.position = position;
            gameObject.transform.rotation =  Quaternion.Euler(0,0,90);
            return gameObject.GetComponent<ISpaceShip>();
        }

        private void SetSpaceShipColor(GameObject go, Color color)
        {
            go.GetComponent<SpriteRenderer>().color = color;
        }

    }
}