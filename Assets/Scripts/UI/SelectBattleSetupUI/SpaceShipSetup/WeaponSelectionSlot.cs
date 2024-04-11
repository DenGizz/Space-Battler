using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.WeaponSelectionUI;
using Assets.Scripts.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;


public class WeaponSelectionSlot : MonoBehaviour
{
    [SerializeField] private WeaponTypeView _weaponTypeView;
    [SerializeField] private ClickableView _weaponTypeClickableView;

    private WeaponSelectionPanelViewModel _selectionPanel;


    public WeaponType SelectedWeaponType
    {
        get => _weaponTypeView.WeaponType;
        set => _weaponTypeView.WeaponType = value;
    }

    private IUiFactory _uiFactory;

    [Inject]
    public void Construct(IUiFactory uiFactory)
    {
        _uiFactory = uiFactory;
    }

    private void Awake()
    {
        _weaponTypeClickableView.OnClicked += OnWeaponTypeClick;
    }

    private void OnWeaponTypeClick(ClickableView view)
    {
        _selectionPanel = _uiFactory.CreateWeaponSelectionPanel();
        _selectionPanel.OnWeaponSelected += OnWeaponSelectedEventHandler;

    }

    private void OnWeaponSelectedEventHandler(WeaponType type)
    {
        SelectedWeaponType = type;
        _selectionPanel.OnWeaponSelected -= OnWeaponSelectedEventHandler;
        Destroy(_selectionPanel.gameObject);
    }
}

