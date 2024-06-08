using Assets.Scripts.AI.AiStrategies;
using Assets.Scripts.Battles;
using Assets.Scripts.Entities;
using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.AI
{
    [RequireComponent(typeof(ISpaceShip))]
    internal class TeamBattleSpaceShipAiBehaviour : MonoBehaviour, ISpaceSipAi, ITickable
    {
        public ISelectTargetStrategy SelectTargetStrategy { get; set; }
        public IUpdateTargetStrategy UpdateTargetStrategy { get; set; }

        private BattleTeam _team;
        private BattleTeam _opponentTeam;

        private ISpaceShip _currentTarget;

        private ISpaceShip _controledSpaceShip;

        private void Awake()
        {
            _controledSpaceShip = GetComponent<ISpaceShip>();
        }

        public void Setup(BattleTeam team, BattleTeam opponentTeam, ISelectTargetStrategy selectTargetStrategy, IUpdateTargetStrategy updateTargetStrategy)
        {
            _team = team;
            _opponentTeam = opponentTeam;
            SelectTargetStrategy = selectTargetStrategy;
            UpdateTargetStrategy = updateTargetStrategy;
        }

        public void Tick()
        {
            if(UpdateTargetStrategy.IsNeedToFindNewTarget(_currentTarget))
                _currentTarget = SelectTargetStrategy.SelectTarget(_opponentTeam.Members);

            AttackTarget(_currentTarget);
        }

        private void AttackTarget(ISpaceShip target)
        {
            if(target == null)
                return;

            foreach (var weapon in _controledSpaceShip.Data.Weapons)
                if (weapon.CanAttack)
                    weapon.Attack(target);
        }
    }
}
