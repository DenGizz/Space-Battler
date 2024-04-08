using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseResumeUI : MonoBehaviour
{
    public Action OnPauseContinueButtonClicked;

    [SerializeField] private Button _pauseContinueButton;
    
    private void Awake()
    {
        _pauseContinueButton.onClick.AddListener(OnPauseContinueButtonClickedEventHandler);
    }

    private void OnPauseContinueButtonClickedEventHandler()
    {
        OnPauseContinueButtonClicked?.Invoke();
    }
}
