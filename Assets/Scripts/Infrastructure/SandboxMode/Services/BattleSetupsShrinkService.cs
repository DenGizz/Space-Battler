using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Game.SandboxMode.BattleSetups;
using Assets.Scripts.Infrastructure.Gameplay.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.Factories
{
    public class BattleSetupsShrinkService : IBattleSetupsShrinkService
    {
        private  readonly ISpaceShipFactory _spaceShipFactory;
        private readonly IWeaponFactory _weaponFactory;
        private readonly IWeaponAttachService _weaponAttachService;
        private readonly IInstantiator _instantiator;

        public BattleSetupsShrinkService(ISpaceShipFactory spaceShipFactory, IWeaponFactory weaponFactory, IWeaponAttachService weaponAttachService, IInstantiator instantiator)
        {
            _spaceShipFactory = spaceShipFactory;
            _weaponFactory = weaponFactory;
            _weaponAttachService = weaponAttachService;
            _instantiator = instantiator;
        }

        public BattleRunner UnShrinkBattleSetup(BattleSetup setup)
        {
            ISpaceShip player = UnShrinkSpaceShip(setup.PlayerSetup);
            ISpaceShip enemy = UnShrinkSpaceShip(setup.EnemySetup);

            BattleData battleData = new BattleData();
            BattleRunner battleRunner = _instantiator.Instantiate<BattleRunner>(new[] { battleData }); //TODO: Implement factory

            battleRunner.AddSpaceShipToAllyTeam(player);
            battleRunner.AddSpaceShipToEnemyTeam(enemy);

            return battleRunner;
        }

        public BattleTeam UnShrinkBattleTeamSetup(BattleTeamSetup setup)
        {
            BattleTeam team = new BattleTeam();

            foreach (var spaceShipSetup in setup.SpaceShipSetups)
            {
                ISpaceShip spaceShip = UnShrinkSpaceShip(spaceShipSetup);
                team.AddMember(spaceShip);
            }

            return team;
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