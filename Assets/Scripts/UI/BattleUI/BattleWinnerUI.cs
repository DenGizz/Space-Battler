using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleWinnerUI : MonoBehaviour
{
    [SerializeField] SpaceShipTypeView _winnerSpaceShipTypeView;
    [SerializeField] TextMeshProUGUI _winnerNameText;

    [SerializeField] string winText = "You win!";
    [SerializeField] string loseText = "You lose!";

    public void SetWinner(ISpaceShip winnerSpaceShip, bool isPlayerWin)
    {
        SpaceShipType winnerSpaceShipType = SpaceShipType.HeavyDefender;

        _winnerSpaceShipTypeView.SpaceShipType = winnerSpaceShipType;
        _winnerNameText.text = isPlayerWin ? winText : loseText;
    }

}
