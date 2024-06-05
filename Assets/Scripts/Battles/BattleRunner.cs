using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using Assets.Scripts.Infrastructure.SandboxMode.Services;

namespace Assets.Scripts.Battles
{
    public class BattleRunner : IBattleRunner
    {
        public BattleData BattleData { get;  }
        public bool IsRunning { get; set; }

        public event EventHandler<BattleEndEventArgs> BattleEnded;
        public event Action BattleStarted;

        public BattleResult? ThisBattleResult { get; private set; }

        private readonly ICombatAiRegistry _combatAiRegistry;
        private readonly IFitSpaceShipsOnScreenService _fitSpaceShipsOnScreenService;

        public BattleRunner(BattleData battleData, ICombatAiRegistry combatAiRegistry, IFitSpaceShipsOnScreenService fitSpaceShipsOnScreenService)
        {
            _combatAiRegistry = combatAiRegistry;
            _fitSpaceShipsOnScreenService = fitSpaceShipsOnScreenService;
            BattleData = battleData;
        }

        public void AddSpaceShipToAllyTeam(ISpaceShip spaceShip)
        {
            BattleData.AllyTeam.AddMember(spaceShip);
            _fitSpaceShipsOnScreenService.FitSpaceShipsOnScreen(BattleData.AllyTeam.Members, IFitSpaceShipsOnScreenService.ScreenSide.Left);
            spaceShip.OnDeath += OnSpaceShipDeathEventHandler;
        }

        public void AddSpaceShipToEnemyTeam(ISpaceShip spaceShip)
        {
            BattleData.EnemyTeam.AddMember(spaceShip);
            _fitSpaceShipsOnScreenService.FitSpaceShipsOnScreen(BattleData.EnemyTeam.Members, IFitSpaceShipsOnScreenService.ScreenSide.Right);
            spaceShip.OnDeath += OnSpaceShipDeathEventHandler;
        }

        public void RemoveSpaceShipFromAllyTeam(ISpaceShip spaceShip)
        {
            BattleData.AllyTeam.AddMember(spaceShip);
        }

        public void RemoveSpaceShipFromEnemyTeam(ISpaceShip spaceShip)
        {
            BattleData.AllyTeam.AddMember(spaceShip);
        }

        public void RunBattle()
        {
            if (!BattleDataValidator.IsBattleDataValid(BattleData, out string reason))
                throw new InvalidOperationException($"Battle data is invalid. Cannot run battle. {reason}");

            IsRunning = true;
            BattleStarted?.Invoke();
        }

        private void OnSpaceShipDeathEventHandler(ISpaceShip spaceShip)
        {
            if(BattleData.AllyTeam.Members.Contains(spaceShip))
                BattleData.AllyTeam.RemoveMember(spaceShip);
            else if(BattleData.EnemyTeam.Members.Contains(spaceShip))
                BattleData.EnemyTeam.RemoveMember(spaceShip);

            CheckTeamDefeatAndEndBattle();
        }

        private void CheckTeamDefeatAndEndBattle()
        {
            if (IsTeamDefeated(BattleData.AllyTeam.Members))
            {
                ThisBattleResult = BattleResult.EnemyTeamWin;
                BattleEnded?.Invoke(this, new BattleEndEventArgs(BattleResult.EnemyTeamWin));
                return;
            }

            if (IsTeamDefeated(BattleData.EnemyTeam.Members))
            {
                ThisBattleResult = BattleResult.AllyTeamWin;
                BattleEnded?.Invoke(this, new BattleEndEventArgs(BattleResult.AllyTeamWin));
                return;
            }
        }

        private bool IsTeamDefeated(IEnumerable<ISpaceShip> teamMembers)
        {
            return teamMembers.All(spaceShip => !spaceShip.Data.IsAlive);
        }
    }
}
