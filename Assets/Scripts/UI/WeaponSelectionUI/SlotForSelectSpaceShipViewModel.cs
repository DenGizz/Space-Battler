using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using Assets.Scripts.Weapons.WeaponConfigs;
using UnityEngine;
using Zenject;

public class SlotForSelectSpaceShipViewModel : MonoBehaviour
{
    [SerializeField] private SpriteView _view;
    [SerializeField] private ClickableView _clickableView;

    public SpaceShipType? SelectedSpaceShipType { get; private set; }

    private SpaceShipSelectionPanelViewModel _spaceShipSelectionPanelViewModel;

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
        _spaceShipSelectionPanelViewModel = _uiFactory.CreateSpaceShipSelectionPanel();
        _spaceShipSelectionPanelViewModel.OnCloseButtonClicked += OnSelectPanelCloseButtonClicked;
        _spaceShipSelectionPanelViewModel.OnSpaceShipSelected += OnSpaceShipSelectedEventHandler;
    }

    private void OnSpaceShipSelectedEventHandler(SpaceShipType spaceShipType)
    {
        SelectedSpaceShipType = spaceShipType;
        _view.Sprite = _staticDataService.GetSpriteFor(spaceShipType);
        Destroy(_spaceShipSelectionPanelViewModel.gameObject);
        _spaceShipSelectionPanelViewModel = null;
    }


    private void OnSelectPanelCloseButtonClicked()
    {
        Destroy(_spaceShipSelectionPanelViewModel.gameObject);
        _spaceShipSelectionPanelViewModel = null;
    }
}
