using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleWinnerUI : MonoBehaviour
{
    [SerializeField] SpaceShipTypeView _winnerSpaceShipTypeView;
    [SerializeField] TextMeshProUGUI _winnerNameText;
    [SerializeField] private Button _returnToMainMenuButton;

    [SerializeField] string winText = "You win!";
    [SerializeField] string loseText = "You lose!";

    public Action OnReturnMainMenuButtonPressed { get; internal set; }

    public void SetWinner(ISpaceShip winnerSpaceShip, bool isPlayerWin)
    {
        SpaceShipType winnerSpaceShipType = SpaceShipType.HeavyDefender;

        _winnerSpaceShipTypeView.SpaceShipType = winnerSpaceShipType;
        _winnerNameText.text = isPlayerWin ? winText : loseText;
    }

    private void Awake()
    {
        _returnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonButtonPressed);
    }

    private void OnReturnToMainMenuButtonButtonPressed()
    {
        OnReturnMainMenuButtonPressed?.Invoke();
    }

    private void OnDestroy()
    {
        _returnToMainMenuButton.onClick.RemoveListener(OnReturnToMainMenuButtonButtonPressed);
    }
}
