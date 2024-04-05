using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Weapons.WeaponConfigs;
using UnityEngine;
using Zenject;

public class SelectWeaponViewModel : MonoBehaviour //ClickHandler
{
    public WeaponType SelectedWeaponType { get; private set; }

    [SerializeField] private WeaponView _weaponView;

    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(IStaticDataService staticDataService)
    {
        _staticDataService = staticDataService;
    }

    private void SelectWeapon(WeaponType weaponType)
    {
        Sprite weaponSprite = _staticDataService.GetUISpriteFor(weaponType);
        _weaponView.WeaponImage.sprite = weaponSprite;
    }

    /*
    public void OnClickHandler()
    {
        (GameObject panelGO, SelectionPanelViewModel panelViewModel)  _uiFactory.CreateSelectionPanel();

        

    }

    private void OnWeaponSelected(WeaponType weaponType)
    {
    }






    */
}
