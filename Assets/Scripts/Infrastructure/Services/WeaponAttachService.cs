using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.Weapons;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public class WeaponAttachService : IWeaponAttachService
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;

        public WeaponAttachService(IGameObjectRegistry gameObjectRegistry)
        {
            _gameObjectRegistry = gameObjectRegistry;
        }

        public void AttachWeaponToSpaceShip(ISpaceShip spaceShip, IWeapon weapon)
        {
            GameObject weaponGameOBject = _gameObjectRegistry.GetWeaponGameObject(weapon);
            GameObject spaceShipGameObject = _gameObjectRegistry.GetSpaceShipGameObject(spaceShip);


            WeaponAttachPoints attachPoints = spaceShipGameObject.GetComponent<WeaponAttachPoints>();


            Transform attachmentPoint = attachPoints.AttachmentPoints.ToArray()[spaceShip.Weapons.Count()];
            weaponGameOBject.transform.SetParent(attachmentPoint);
            weaponGameOBject.transform.localPosition = Vector3.zero;
            weaponGameOBject.transform.rotation = spaceShipGameObject.transform.rotation;

            spaceShip.AddWeapon(weapon);
        }

        public bool CanAttachWeaponToSpaceShip(ISpaceShip spaceShip, IWeapon weapon)
        {
            if (spaceShip.Weapons.Count() <= spaceShip.Config.WeaponSlots)
                return false;

            GameObject weaponGameObject = _gameObjectRegistry.GetWeaponGameObject(weapon);
            GameObject spaceShipGameObject = _gameObjectRegistry.GetSpaceShipGameObject(spaceShip);

            if (weaponGameObject == null || spaceShipGameObject == null)
                return false;

            if(!spaceShipGameObject.TryGetComponent(out WeaponAttachPoints attachPoints))
                return false;

            if(attachPoints.AttachmentPoints.Count() <= spaceShip.Weapons.Count())
                return false;

            return true;
        }
    }
}