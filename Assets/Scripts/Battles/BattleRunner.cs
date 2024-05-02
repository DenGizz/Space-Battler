using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using System;
using System.Collections.Generic;
using Assets.Scripts.Entities.SpaceShips;
using System.Linq;

namespace Assets.Scripts.Battles.BattleRun
{
    public class BattleRunner : IBattleRunner
    {
        public BattleData BattleData { get;  }
        public bool IsRunning { get; set; }

        public event EventHandler<BattleEndEventArgs> BattleEnded;

        public BattleResult? ThisBattleResult { get; private set; }

        private readonly ICombatAiRegistry _combatAiRegistry;

        public BattleRunner(BattleData battleData, ICombatAiRegistry combatAiRegistry)
        {
            _combatAiRegistry = combatAiRegistry;
            BattleData = battleData;
        }

        public void AddSpaceShipToAllyTeam(ISpaceShip spaceShip)
        {
            BattleData.AllyTeamMembers.Add(spaceShip);
            spaceShip.OnDeath += OnSpaceShipDeathEventHandler;
        }

        public void AddSpaceShipToEnemyTeam(ISpaceShip spaceShip)
        {
            BattleData.EnemyTeamMembers.Add(spaceShip);
            spaceShip.OnDeath += OnSpaceShipDeathEventHandler;
        }

        public void RemoveSpaceShipFromAllyTeam(ISpaceShip spaceShip)
        {
            BattleData.AllyTeamMembers.Remove(spaceShip);
        }

        public void RemoveSpaceShipFromEnemyTeam(ISpaceShip spaceShip)
        {
            BattleData.EnemyTeamMembers.Remove(spaceShip);
        }

        public void RunBattle()
        {
            if (!BattleDataValidator.IsBattleDataValid(BattleData, out string reason))
                throw new InvalidOperationException($"Battle data is invalid. Cannot run battle. {reason}");

            BattleData.AllyTeamMembers.ForEach(spaceShip => FindAndSetTargetForSpaceShip(spaceShip, BattleData.EnemyTeamMembers));
            BattleData.EnemyTeamMembers.ForEach(spaceShip => FindAndSetTargetForSpaceShip(spaceShip, BattleData.AllyTeamMembers));

            BattleData.AllyTeamMembers.ForEach(spaceShip => _combatAiRegistry.GetAi(spaceShip).EnterCombatMode());
            BattleData.EnemyTeamMembers.ForEach(spaceShip => _combatAiRegistry.GetAi(spaceShip).EnterCombatMode());
        }

        private void FindAndSetTargetForSpaceShip(ISpaceShip spaceShip, List<ISpaceShip> opponentTeamMembers)
        {
            ICombatAi combatAi = _combatAiRegistry.GetAi(spaceShip);
            ISpaceShip target = GetRandomTeamMember(opponentTeamMembers);

            combatAi.SetTarget(target);
        }

        private ISpaceShip GetRandomTeamMember(List<ISpaceShip> teamMembers)
        {
            return teamMembers[UnityEngine.Random.Range(0, teamMembers.Count)];
        }

        private void OnSpaceShipDeathEventHandler(ISpaceShip spaceShip)
        {
            CheckTeamDefeatAndEndBattle();
        }

        private void CheckTeamDefeatAndEndBattle()
        {
            if (IsTeamDefeated(BattleData.AllyTeamMembers))
            {
                ThisBattleResult = BattleResult.EnemyTeamWin;
                BattleEnded?.Invoke(this, new BattleEndEventArgs(BattleResult.EnemyTeamWin));
                return;
            }

            if (IsTeamDefeated(BattleData.EnemyTeamMembers))
            {
                ThisBattleResult = BattleResult.AllyTeamWin;
                BattleEnded?.Invoke(this, new BattleEndEventArgs(BattleResult.AllyTeamWin));
                return;
            }
        }

        private bool IsTeamDefeated(List<ISpaceShip> teamMembers)
        {
            return teamMembers.All(spaceShip => !spaceShip.Data.IsAlive);
        }
    }
}
