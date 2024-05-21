using System;
using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.UI.BaseUI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews
{
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
            }     
        }

        public Action OnSpaceShipTypeSelected;

        private IUiElementsFactory _uiFactory;

        [Inject]
        public void Construct(IUiElementsFactory uiFactory)
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
            _selectionPanel.OnCloseButtonClicked += OnSelectionPanelCloseButtonClickedEventHandler;

        }

        private void OnSpaceShipSelectedEventHandler(SpaceShipType type)
        {
            SelectedSpaceShipType = type;
            CloseSelectionPanel();
            OnSpaceShipTypeSelected?.Invoke();
        }

        private void OnSelectionPanelCloseButtonClickedEventHandler()
        {
            CloseSelectionPanel();
        }

        private void CloseSelectionPanel()
        {

            _selectionPanel.OnCloseButtonClicked -= OnSelectionPanelCloseButtonClickedEventHandler;
            Destroy(_selectionPanel.gameObject);
            _selectionPanel = null;
        }
    }
}