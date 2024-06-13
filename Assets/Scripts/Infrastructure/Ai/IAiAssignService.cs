using Assets.Scripts.AI;
using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Ai
{
    public interface IAiAssignService
    {
        void AssignTeamMemberAiToSpaceShip(ISpaceShip spaceShip, BattleTeam team, BattleTeam opponentTeam);
    }
}
