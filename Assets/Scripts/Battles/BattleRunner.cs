using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Battles.BattleRun
{
    public class BattleRunner : IBattleRunner
    {
        public BattleData BattleData { get; private set; }

        public event EventHandler<BattleEndEventArgs> BattleEnded;

        private readonly ICombatAiRegistry _combatAiRegistry;

        public BattleRunner(ICombatAiRegistry combatAiRegistry)
        {
            _combatAiRegistry = combatAiRegistry;
            BattleData = new BattleData();
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

            BattleData.AllyTeamMembers.ForEach(spaceShip => _combatAiRegistry.GetAi(spaceShip).StartCombat());
            BattleData.EnemyTeamMembers.ForEach(spaceShip => _combatAiRegistry.GetAi(spaceShip).StartCombat());
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
            if(BattleData.AllyTeamMembers.Contains(spaceShip))
                RemoveSpaceShipFromAllyTeam(spaceShip);

            if(BattleData.EnemyTeamMembers.Contains(spaceShip))
                RemoveSpaceShipFromEnemyTeam(spaceShip);

            CheckTeamDefeatAndEndBattle();
        }

        private void CheckTeamDefeatAndEndBattle()
        {
            if (IsTeamDefeated(BattleData.AllyTeamMembers))
            {
                BattleEnded?.Invoke(this, new BattleEndEventArgs(BattleResult.EnemyTeamWin));
                return;
            }

            if (IsTeamDefeated(BattleData.EnemyTeamMembers))
            {
                BattleEnded?.Invoke(this, new BattleEndEventArgs(BattleResult.AllyTeamWin));
                return;
            }
        }

        private bool IsTeamDefeated(List<ISpaceShip> teamMembers)
        {
            return teamMembers.Count == 0;
        }
    }
}
