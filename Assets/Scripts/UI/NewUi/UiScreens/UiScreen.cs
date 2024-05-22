using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class UiScreen : MonoBehaviour
{
    public bool IsInitialized { get; private set; }
    public bool IsVisible { get; private set; }

    protected Ui _ui;

    public virtual void Setup(Ui ui)
    {
        if(IsInitialized)
            throw new System.Exception("UiScreen is already initialized");

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
