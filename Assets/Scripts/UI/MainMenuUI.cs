using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button _startBattleButton;

    public event Action OnStartBattleButtonClicked;

    private void Awake()
    {
        _startBattleButton.onClick.AddListener(OnStartBattleButtonClick);
    }

    private void OnStartBattleButtonClick()
    {
        OnStartBattleButtonClicked?.Invoke();
    }
}
