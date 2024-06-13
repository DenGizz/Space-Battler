using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Game.SandboxMode.BattleSetups;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.Infrastructure.Ui.Services;
using Assets.Scripts.UI.UiElements;
using Assets.Scripts.UI.ViewModels.BaseViewModels;
using Assets.Scripts.UI.ViewModels.SpaceShipSetupEditor;
using Assets.Scripts.UI.ViewModels.SpaceShipViewModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BattleTeamSetupEditor : MonoBehaviour
{
    [SerializeField] private Transform _teamSpaceShipSetupViewModelsContainer;
    [SerializeField] private Button _addTeamMemberButton;
    [SerializeField] private Button _deleteAllMembersButton;
    private List<ClickableView> _clickableViews;

    private IRandomSetupService _randomSetupService;
    private IUiWindowsService _uiWindowsService;
    private IUiElementsFactory _uiElementsFactory;

    private BattleTeamSetup _battleTeamSetup;

    [Inject]
    public void Construct(IUiWindowsService uiWindowsService, IUiElementsFactory uiElementsFactory, IRandomSetupService randomSetupService)
    {
        _uiWindowsService = uiWindowsService;
        _uiElementsFactory = uiElementsFactory;
        _randomSetupService = randomSetupService;
    }

    private void Awake()
    {
        _clickableViews = new List<ClickableView>();
        _addTeamMemberButton.onClick.AddListener(CreateAndAddNewTeamMemberSetup);
        _deleteAllMembersButton.onClick.AddListener(DeleteAllTeamMembers);
    }

    public void SetBattleTeamSetup(BattleTeamSetup battleTeamSetup)
    {
        _battleTeamSetup = battleTeamSetup;

        DestroyAllSpaceShipSetupViews();

        foreach (SpaceShipSetup spaceShipSetup in _battleTeamSetup.SpaceShipSetups)
           CreateSpaceShipSetupView(spaceShipSetup);
    }

    private void CreateAndAddNewTeamMemberSetup()
    {
        SpaceShipSetup newSpaceShipSetup = new SpaceShipSetup();
        _randomSetupService.RandomizeSpaceShipSetup(newSpaceShipSetup);
        _battleTeamSetup.SpaceShipSetups.Add(newSpaceShipSetup);
        CreateSpaceShipSetupView(newSpaceShipSetup);
    }

    private void DeleteAllTeamMembers()
    {
        _battleTeamSetup.SpaceShipSetups.Clear();
        DestroyAllSpaceShipSetupViews();
    }

    private void DestroyAllSpaceShipSetupViews()
    {
        foreach (ClickableView view in _clickableViews)
        {
            Destroy(view.gameObject);
            view.OnClicked -= OnSpaceShipSetupViewClicked;
        }
        _clickableViews.Clear();
    }

    private void CreateSpaceShipSetupView(SpaceShipSetup spaceShipSetup)
    {
        SpaceShipSetupViewModel view = _uiElementsFactory.CreateSpaceShipSetupRowView();
        view.transform.SetParent(_teamSpaceShipSetupViewModelsContainer, false);
        view.SpaceShipSetup = spaceShipSetup;
        ClickableView clickableComponent = GatOrAddClickableComponent(view);
        clickableComponent.OnClicked += OnSpaceShipSetupViewClicked;
        _clickableViews.Add(clickableComponent);
    }

    private ClickableView GatOrAddClickableComponent(MonoBehaviour view)
    {
        ClickableView clickableComponent = view.GetComponent<ClickableView>();
        if (clickableComponent == null)
            clickableComponent = view.gameObject.AddComponent<ClickableView>();
        return clickableComponent;
    }

    private void OpenSpaceShipSetupEditorInWindow(SpaceShipSetup setup)
    {
        WindowPanel window = _uiWindowsService.OpenWindow();
        SpaceShipSetupEditViewModel setupEditor = _uiElementsFactory.CreateSpaceShipSetupEditView();
        setupEditor.SetSpaceShipSetupForEdit(setup);
        window.AddContent(setupEditor.gameObject);
    }

    private void OnSpaceShipSetupViewClicked(ClickableView view)
    {
        OpenSpaceShipSetupEditorInWindow(view.GetComponent<SpaceShipSetupViewModel>().SpaceShipSetup);
    }
}
