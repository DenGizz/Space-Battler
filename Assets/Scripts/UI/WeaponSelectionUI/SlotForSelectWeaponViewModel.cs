using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Weapons.WeaponConfigs;
using UnityEngine;
using Zenject;

public class SlotForSelectWeaponViewModel : MonoBehaviour
{
    [SerializeField] private SpriteView _view;
    [SerializeField] private ClickableView _clickableView;

    private WeaponSelectionPanelViewModel _weaponSelectionPanelViewModel;

    private IUIFactory _uiFactory;
    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(IUIFactory uiFactory, IStaticDataService staticDataService)
    {
        _uiFactory = uiFactory;
        _staticDataService = staticDataService;
    }

    private void Awake()
    {
        _clickableView.OnClicked += OnViewClickedEventHandler;
    }

    private void OnViewClickedEventHandler(ClickableView clickableView)
    {
        _weaponSelectionPanelViewModel = _uiFactory.CreateWeaponSelectionPanelViewPanel();
        _weaponSelectionPanelViewModel.OnCloseButtonClicked += OnSelectPanelCloseButtonClicked;
        _weaponSelectionPanelViewModel.OnWeaponSelected += OnWeaponSelectedEventHandler;
    }

    private void OnWeaponSelectedEventHandler(WeaponType weaponType)
    {
        _view.Sprite = _staticDataService.GetSpriteFor(weaponType);
        Destroy(_weaponSelectionPanelViewModel.gameObject);
        _weaponSelectionPanelViewModel = null;
    }


    private void OnSelectPanelCloseButtonClicked()
    {
        Destroy(_weaponSelectionPanelViewModel.gameObject);
        _weaponSelectionPanelViewModel = null;
    }
}
