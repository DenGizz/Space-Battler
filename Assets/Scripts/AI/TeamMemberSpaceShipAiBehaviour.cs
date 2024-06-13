using Assets.Scripts.AI.AiStrategies;
using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.AI
{
    [RequireComponent(typeof(ISpaceShip))]
    public class TeamMemberSpaceShipAiBehaviour : MonoBehaviour, ISpaceShipAi, ITickable
    {
        private ISpaceShip _spaceShip;
        private BattleTeam _team;
        private BattleTeam _opponentTeam;

        private ISpaceShip _target;

        public ISelectTargetStrategy SelectTargetStrategy { get; set; }
        public IUpdateTargetStrategy UpdateTargetStrategy { get; set; }

        private void Awake()
        {
            _spaceShip = GetComponent<ISpaceShip>();
        }

        public void Construct(BattleTeam team, BattleTeam opponentTeam)
        {
            _team = team;
            _opponentTeam = opponentTeam;
        }

        public void Tick()
        {
            if (!_spaceShip.Data.IsAlive)
                return;

            if(UpdateTargetStrategy.IsNeedToFindNewTarget(_target))
                _target = SelectTargetStrategy.SelectTarget(_opponentTeam.Members);

            if(_target != null)
                _spaceShip.Attack(_target);
        }
    }
}
