using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.Weapons.WeaponConfigs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpaceShipTypeView : MonoBehaviour
{
    public SpaceShipType SpaceShipType
    {
        get => _weaponType;
        set
        {
            _weaponType = value;
            UpdateView();
        }
    }

    [SerializeField] private SpriteView _spriteView;
    private SpaceShipType _weaponType = SpaceShipType.None;

    private  IStaticDataService _staticDataService;

    [Inject]
    public void Construct(IStaticDataService staticDataService)
    {
        _weaponType = SpaceShipType.None;
        _staticDataService = staticDataService;
    }

    private void UpdateView()
    {
        if (_weaponType == SpaceShipType.None)
        {
            _spriteView.Sprite = null;
            return;
        }

        SpaceShipDescriptor descriptor = _staticDataService.GetSpaceShipDescriptor(_weaponType);
        _spriteView.Sprite = descriptor.Sprite;
    }
}
