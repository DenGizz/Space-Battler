using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Gameplay.Services;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Gameplay.Factories
{
    public class BattleSetupsShrinkService : IBattleSetupsShrinkService
    {
        private  readonly ISpaceShipFactory _spaceShipFactory;
        private readonly IWeaponFactory _weaponFactory;
        private readonly IWeaponAttachService _weaponAttachService;

        public BattleSetupsShrinkService(ISpaceShipFactory spaceShipFactory, IWeaponFactory weaponFactory, IWeaponAttachService weaponAttachService)
        {
            _spaceShipFactory = spaceShipFactory;
            _weaponFactory = weaponFactory;
            _weaponAttachService = weaponAttachService;
        }

        public ISpaceShip UnShrinkSpaceShip(SpaceShipSetup setup)
        {
            ISpaceShip player = _spaceShipFactory.CreateSpaceShip(setup.SpaceShipType);

            foreach (var weaponType in setup.WeaponTypes)
            {
                if(weaponType == WeaponType.None)
                    continue;

                IWeapon weapon = _weaponFactory.CreateWeapon(weaponType);
                _weaponAttachService.AttachWeaponToSpaceShip(player, weapon);
            }

            return player;
        }
    }
}