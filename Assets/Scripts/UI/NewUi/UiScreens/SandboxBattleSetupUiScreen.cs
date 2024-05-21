using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.NewUi.SpaceShipSetupEditPanel;
using UnityEngine;
using UnityEngine.UI;

public class SandboxBattleSetupUiScreen : MonoBehaviour
{
    [SerializeField] private SpaceShipSetupEditViewModel _playerSetupEditor;
    [SerializeField] private SpaceShipSetupEditViewModel _enemySetupEditor;
    [SerializeField] private Button _startBattleButton;

    public event Action OnStartBattleButtonClicked;

    public void Initialize(SpaceShipSetup playerSetup, SpaceShipSetup spaceShipSetup)
    {
        _playerSetupEditor.Initialize(playerSetup);
        _enemySetupEditor.Initialize(spaceShipSetup);
    }

    private void Awake()
    {
        _startBattleButton.onClick.AddListener(OnStartBattleButtonClicked.Invoke);
    }

    private void OnDestroy()
    {
        _startBattleButton.onClick.RemoveListener(OnStartBattleButtonClicked.Invoke);
    }
}
