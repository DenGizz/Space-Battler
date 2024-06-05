using Assets.Scripts.Battles;
using Assets.Scripts.Entities;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.AI.UnitsAI
{
    [RequireComponent(typeof(ICombatAi), typeof(ISpaceShip))]
    public class InBattleEnemySearchAi : MonoBehaviour, ITickable
    {
        private ICombatAi _combatAi;
        private IBattleRunnerProvider _battleRunnerProvider;
        private ISpaceShip _spaceShip;
        private BattleTeam _opponentTeam;

        [Inject]
        public void Construct(IBattleRunnerProvider battleRunnerProvider)
        {
            _battleRunnerProvider = battleRunnerProvider;
        }

        public void Awake()
        {
            _combatAi = GetComponent<ICombatAi>();
            _spaceShip = GetComponent<ISpaceShip>();
        }

        public void Tick()
        {
            if (_combatAi.Target != null && _combatAi.Target.Data.IsAlive)
                return;

            if (_opponentTeam == null)
                FindOpponentTeam();

            _combatAi.Target = FindTarget();
        }

        private ISpaceShip FindTarget()
        {
            return SelectRandomSpaceShip(_opponentTeam.Members);
        }

        private ISpaceShip SelectRandomSpaceShip(IEnumerable<ISpaceShip> spaceShips)
        {
            if (spaceShips == null || spaceShips.Count() == 0)
                return null;

            return spaceShips.ElementAt(UnityEngine.Random.Range(0, spaceShips.Count()));
        }

        private void FindOpponentTeam()
        {
            if (_battleRunnerProvider.CurrentBattleRunner == null)
                return;

            BattleTeam allyTeam = _battleRunnerProvider.CurrentBattleRunner.BattleData.AllyTeam;
            BattleTeam enemyTeam = _battleRunnerProvider.CurrentBattleRunner.BattleData.EnemyTeam;

            if (allyTeam.Members.Contains(_spaceShip))
                _opponentTeam = enemyTeam;
            else if (enemyTeam.Members.Contains(_spaceShip))
                _opponentTeam = allyTeam;
            else
                throw new InvalidOperationException("Space ship is not a member of any team in current battle.");
        }
    }
}
