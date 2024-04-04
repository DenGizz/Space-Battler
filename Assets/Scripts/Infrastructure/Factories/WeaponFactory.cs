using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.SpaceShip;
using Assets.Scripts.SpaceShip.SpaceShipComponents;
using Assets.Scripts.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly IAssetsProvider _assetsProvider;

        public WeaponFactory(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public IWeapon CreateWeapon(WeaponType weaponType, Vector3 position, float zRotation)
        {
            GameObject weaponPrefab = _assetsProvider.GetWeaponPrefab(weaponType);
            GameObject weaponGameObject = GameObject.Instantiate(weaponPrefab, position, Quaternion.Euler(0, 0, zRotation));
            return weaponGameObject.GetComponentInChildren<IWeapon>();
        }
    }
}
