using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Weapons.WeaponConfigs;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

public class WeaponSelectionPanelViewModel : MonoBehaviour
{
    [SerializeField] private ClickableViewsPanel _clickableViewsPanel;

    private Dictionary<GameObject, WeaponType> _viewToType;
    private List<ClickableView> _clickableViews;

    private IUIFactory _uiFactory;
    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(IUIFactory uiFactory, IStaticDataService staticDataService)
    {
        _uiFactory = uiFactory;
        _staticDataService = staticDataService;
    }

    private void Start()
    {
        _clickableViews = new List<ClickableView>();
        _viewToType = new Dictionary<GameObject, WeaponType>();

        IEnumerable<WeaponConfigSO> configs = _staticDataService.GetWeaponConfigs();

        foreach (var config in configs)
        {
            DescriptionRowView descriptionRow = _uiFactory.CreateWeaponDescriptionRowView();
            descriptionRow.TitleText = config.WeaponType.ToString();
            descriptionRow.DescriptionText = $"Damage: {config.Damage}.\nCold down: {config.ColdDownTime} sec.";
            descriptionRow.Sprite = config.Sprite;
            _clickableViewsPanel.AddContent(descriptionRow.gameObject);
            _viewToType.Add(descriptionRow.gameObject, config.WeaponType);

            if(descriptionRow.TryGetComponent(out ClickableView clickable))
            {
                _clickableViews.Add(clickable);
                clickable.OnClicked += OnRowClickedEventHandler;
            }
        }

    }

    private void OnRowClickedEventHandler(ClickableView row)
    {
        Debug.Log($"Weapon selected: {_viewToType[row.gameObject]}");
    }
}
