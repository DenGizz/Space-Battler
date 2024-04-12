using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Weapons;
using Assets.Scripts.Weapons.WeaponConfigs;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class SpaceShipFromSetupFactory : ISpaceShipFromSetupFactory
    {
        private  readonly ISpaceShipFactory _spaceShipFactory;
        private readonly IWeaponFactory _weaponFactory;
        private readonly IWeaponAttachService _weaponAttachService;

        public SpaceShipFromSetupFactory(ISpaceShipFactory spaceShipFactory, IWeaponFactory weaponFactory, IWeaponAttachService weaponAttachService)
        {
            _spaceShipFactory = spaceShipFactory;
            _weaponFactory = weaponFactory;
            _weaponAttachService = weaponAttachService;
        }

        public ISpaceShip CreateSpaceShipFromSetup(SpaceShipSetup setup, Vector3 position, float zRotation)
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