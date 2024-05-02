using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class ShrinkService : IShrinkService
    {
        private  readonly ISpaceShipFactory _spaceShipFactory;
        private readonly IWeaponFactory _weaponFactory;
        private readonly IWeaponAttachService _weaponAttachService;

        public ShrinkService(ISpaceShipFactory spaceShipFactory, IWeaponFactory weaponFactory, IWeaponAttachService weaponAttachService)
        {
            _spaceShipFactory = spaceShipFactory;
            _weaponFactory = weaponFactory;
            _weaponAttachService = weaponAttachService;
        }

        public ISpaceShip UnShrinkSpaceShip(SpaceShipSetup setup, Vector3 position, float zRotation)
        {
            ISpaceShip player = _spaceShipFactory.CreateSpaceShip(setup.SpaceShipType, position, zRotation);

            foreach (var weaponType in setup.WeaponTypes)
            {
                if(weaponType == WeaponType.None)
                    continue;

                IWeapon weapon = _weaponFactory.CreateWeapon(weaponType, position + Random.insideUnitSphere, zRotation);
                _weaponAttachService.AttachWeaponToSpaceShip(player, weapon);
            }

            return player;
        }
    }
}