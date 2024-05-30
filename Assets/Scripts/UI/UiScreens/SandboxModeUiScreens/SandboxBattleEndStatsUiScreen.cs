using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.UI.NewUi.Uis;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandboxBattleEndStatsUiScreen : UiScreen, IGameStateChangeEventSource
{
    [SerializeField] private Button _returnToEditorButton;

    public event Action<GameStateChangeEvent> OnGameStateChangeEvent;

    private void Awake ()
    {
        _returnToEditorButton.onClick.AddListener(OnReturnToEditorButtonClicked);
    }

    private void OnReturnToEditorButtonClicked()
    {
        OnGameStateChangeEvent?.Invoke(GameStateChangeEvent.CloseBattleEndScreen);
    }
}
