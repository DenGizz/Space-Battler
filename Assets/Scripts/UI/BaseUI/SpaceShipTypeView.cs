using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using Assets.Scripts.Weapons.WeaponConfigs;
using UnityEngine;
using Zenject;

public class SpaceShipTypeView : MonoBehaviour
{
    [SerializeField] private SpriteView _spriteView;

    private IStaticDataService _staticDataService;

    private SpaceShipType? _spaceShipType;

    [Inject]
    private void Construct( IStaticDataService staticDataService)
    {
        _staticDataService = staticDataService;
    }

    public SpaceShipType? SpaceShipType
    {
        get => _spaceShipType;
        set
        {
            _spaceShipType = value;

            if (value == null)
            {
                _spriteView.Sprite = null;
                return;
            }

            _spriteView.Sprite = _staticDataService.GetSpriteFor(_spaceShipType.Value);
        }
    }
}
