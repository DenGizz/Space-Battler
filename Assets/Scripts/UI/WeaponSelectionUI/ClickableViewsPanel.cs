using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Weapons.WeaponConfigs;
using UnityEngine;
using UnityEngine.UI;

public class ClickableViewsPanel : MonoBehaviour
{
    public Action OnCloseButtonClicked;
    public Action<ClickableView> OnViewClicked;

    private List<ClickableView> _clickableViews;

    [SerializeField] private RectTransform _contentContainer;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        _clickableViews = new List<ClickableView>();
        _closeButton.onClick.AddListener(OnCloseButtonClickedEventHandler);
    }

    public void AddContent(GameObject viewGameObject)
    {
        viewGameObject.transform.SetParent(_contentContainer);

        if (viewGameObject.TryGetComponent(out ClickableView clickableView))
        {
            _clickableViews.Add(clickableView);
            clickableView.OnClicked += OnViewClickEventHandler;
        }
    }

    public void RemoveContent(GameObject viewGameObject)
    {
        if (viewGameObject.TryGetComponent(out ClickableView clickableView))
        {
            _clickableViews.Remove(clickableView);
            clickableView.OnClicked -= OnViewClickEventHandler;
        }
    }


    private void OnViewClickEventHandler(ClickableView view)
    {
        OnViewClicked?.Invoke(view);
    }

    private void OnCloseButtonClickedEventHandler()
    {
        OnCloseButtonClicked?.Invoke();
    }
}
