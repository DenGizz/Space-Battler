using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities.SpaceShips
{
    [RequireComponent(typeof(ISpaceShip))]
    public class SpaceShipDeathBehaviour : MonoBehaviour
    {
        private ISpaceShip _spaceShip;

        private void Awake()
        {
            _spaceShip = GetComponent<ISpaceShip>();
            _spaceShip.OnDeath += OnSpaceShipDeathEventHandler;
        }

        private void OnSpaceShipDeathEventHandler(ISpaceShip spaceShip)
        {
            Destroy(gameObject);
            _spaceShip.OnDeath -= OnSpaceShipDeathEventHandler;
        }
    }
}
