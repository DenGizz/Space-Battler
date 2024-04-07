using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpriteView : MonoBehaviour
{
    public Sprite Sprite
    {
        get => _image.sprite;
        set
        {
            _image.color = value == null ? new Color(0, 0, 0, 0) : Color.white;
            _image.sprite = value;
        }
    }

    [SerializeField] private Image _image;
    [SerializeField] private Sprite _defaultSprite;


#if UNITY_EDITOR
    private void OnValidate()
    {
        Sprite = _defaultSprite;
    }
#endif

}
