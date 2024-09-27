using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Buttons/ToogleIconButton")]
[RequireComponent(typeof(Button))]
public class ToogleIconButton : MonoBehaviour
{
    [SerializeField] private Sprite _toogledOnSprite;
    [SerializeField] private Sprite _toogledOffSprite;

    [SerializeField] private Image _buttonIconImage;

    public bool IsToogledOn { get; set; }
    public event Action<bool> Toogled;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnButtonPressed);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed()
    {
        IsToogledOn = !IsToogledOn;

        _buttonIconImage.sprite = IsToogledOn ? _toogledOnSprite : _toogledOffSprite;

        Toogled?.Invoke(IsToogledOn);
    }
}
