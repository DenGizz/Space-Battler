using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.UI.ViewModels.BaseViewModels;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.ViewModels.SpaceShipViewModels
{
    [RequireComponent(typeof(SpriteView))]
    public class SpaceShipTypeViewModel : MonoBehaviour, ISpaceShipViewModel
    {
        public SpaceShipType SpaceShipType
        {
            get => _spaceShipType;
            set
            {
                _spaceShipType = value;
                UpdateView();
            }
        }

        private SpriteView _spriteView;
        private SpaceShipType _spaceShipType = SpaceShipType.None;

        protected  IStaticDataService _staticDataService;

        [Inject]
        public void Construct(IStaticDataService staticDataService)
        {
            _spaceShipType = SpaceShipType.None;
            _staticDataService = staticDataService;
        }

        protected virtual void Awake()
        {
            _spriteView = GetComponent<SpriteView>();
        }

        protected virtual void UpdateView()
        {
            if (_spaceShipType == SpaceShipType.None)
            {
                _spriteView.Sprite = null;
                return;
            }

            int ss;
            SpaceShipDescriptor descriptor = _staticDataService.GetSpaceShipDescriptor(_spaceShipType);
            _spriteView.Sprite = descriptor.Sprite;
        }
    }
}
