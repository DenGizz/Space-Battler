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

        public SpaceShipFromSetupFactory(ISpaceShipFactory spaceShipFactory, IWeaponFactory weaponFactory)
        {
            _spaceShipFactory = spaceShipFactory;
            _weaponFactory = weaponFactory;
        }

        public ISpaceShip CreateSpaceShipFromSetup(SpaceShipSetup setup, Vector3 position, float zRotation)
        {
            ISpaceShip player = _spaceShipFactory.CreateSpaceShip(setup.SpaceShipType, position, zRotation);

            foreach (var weaponType in setup.WeaponTypes)
            {
                if(weaponType == WeaponType.None)
                    continue;

                IWeapon weapon = _weaponFactory.CreateWeapon(weaponType, position + Random.insideUnitSphere, zRotation);
                player.AddWeapon(weapon);
            }

            return player;
        }
    }
}