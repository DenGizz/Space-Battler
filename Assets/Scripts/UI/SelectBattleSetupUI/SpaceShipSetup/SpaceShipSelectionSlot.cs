using System;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.WeaponSelectionUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpaceShipSelectionSlot : MonoBehaviour
{
    [SerializeField] private SpaceShipTypeView _spaceShipTypeView;
    [SerializeField] private ClickableView _spaceShipTypeClickableView;
    
    private SpaceShipSelectionPanelViewModel _selectionPanel;


    public SpaceShipType SelectedSpaceShipType
    {
        get => _spaceShipTypeView.SpaceShipType;
        set
        {
            _spaceShipTypeView.SpaceShipType = value;
            OnSelectedSpaceShipTypeChanged?.Invoke();
        }     
    }

    public Action OnSelectedSpaceShipTypeChanged;

    private IUIFactory _uiFactory;

    [Inject]
    public void Construct(IUIFactory uiFactory)
    {
        _uiFactory = uiFactory;
    }

    private void Awake()
    {
        _spaceShipTypeClickableView.OnClicked += OnSpaceShipTypeClick;
    }

    private void OnSpaceShipTypeClick(ClickableView view)
    {
        _selectionPanel = _uiFactory.CreateSpaceShipSelectionPanel();
        _selectionPanel.OnSpaceShipSelected += OnSpaceShipSelectedEventHandler;

    }

    private void OnSpaceShipSelectedEventHandler(SpaceShipType type)
    {
        SelectedSpaceShipType = type;
        _selectionPanel.OnSpaceShipSelected -= OnSpaceShipSelectedEventHandler;
        Destroy(_selectionPanel.gameObject);
        _selectionPanel = null;
    }
}
