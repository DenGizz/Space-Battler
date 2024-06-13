using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Entities.Weapons;
using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Game.SandboxMode.BattleSetups;
using Assets.Scripts.Infrastructure.Ai;
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
        private readonly IAiAssignService _aiAssignService;

        public BattleSetupsShrinkService(ISpaceShipFactory spaceShipFactory, IWeaponFactory weaponFactory, IWeaponAttachService weaponAttachService, IInstantiator instantiator, IAiAssignService aiAssignService)
        {
            _spaceShipFactory = spaceShipFactory;
            _weaponFactory = weaponFactory;
            _weaponAttachService = weaponAttachService;
            _instantiator = instantiator;
            _aiAssignService = aiAssignService;
        }

        public BattleRunner UnShrinkBattleSetup(BattleSetup setup)
        {
            BattleData battleData = new BattleData();
            BattleRunner battleRunner = _instantiator.Instantiate<BattleRunner>(new[] { battleData });

            foreach( var spaceShipSetup in setup.EnemyTeamSetup.SpaceShipSetups)
            {
                ISpaceShip spaceShip = UnShrinkSpaceShip(spaceShipSetup);
                _aiAssignService.AssignTeamMemberAiToSpaceShip(spaceShip, battleData.EnemyTeam, battleData.AllyTeam);
                battleRunner.AddSpaceShipToEnemyTeam(spaceShip);
            }

            foreach (var spaceShipSetup in setup.PlayerTeamSetup.SpaceShipSetups)
            {
                ISpaceShip spaceShip = UnShrinkSpaceShip(spaceShipSetup);
                _aiAssignService.AssignTeamMemberAiToSpaceShip(spaceShip, battleData.AllyTeam, battleData.EnemyTeam);
                battleRunner.AddSpaceShipToAllyTeam(spaceShip);
            }

            return battleRunner;
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