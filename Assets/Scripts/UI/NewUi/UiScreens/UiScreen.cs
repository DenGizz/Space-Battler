using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class UiScreen : MonoBehaviour, IInitializable
{
    public bool IsInitialized { get; private set; }
    public bool IsVisible { get; private set; }

    public virtual void Initialize()
    {
        IsInitialized = true;
    }

    public void Show()
    {
        IsVisible = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        IsVisible = false;
        gameObject.SetActive(false);
    }
}
