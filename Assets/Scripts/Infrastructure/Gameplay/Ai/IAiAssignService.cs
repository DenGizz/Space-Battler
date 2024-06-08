using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAiAssignService 
{
    public void AssignTeamBattleAi(ISpaceShip spaceShip, BattleTeam team, BattleTeam opponentTeam);
}
