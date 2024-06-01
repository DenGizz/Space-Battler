using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.UI.ViewModels.BaseViewModels;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.ViewModels.SpaceShipViewModels
{
    [RequireComponent(typeof(DescriptionRowView))]
    public class SpaceShipTypeRowViewModel : MonoBehaviour, ISpaceShipViewModel
    {
        [SerializeField] private SpaceShipTypeViewModel _spaceShipTypeViewModel;
        private DescriptionRowView _descriptionRowView;
        public Entities.SpaceShips.SpaceShipConfigs.SpaceShipType SpaceShipType
        {
            get => _spaceShipTypeViewModel.SpaceShipType;
            set
            {
                _spaceShipTypeViewModel.SpaceShipType = value;
                UpdateDescription();
            }
        }

        private IStaticDataService _staticDataService;

        [Inject]
        public void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        private void Awake()
        {
            _descriptionRowView = GetComponent<DescriptionRowView>();
        }

        private void UpdateDescription()
        {
            _descriptionRowView.TitleText = GetTitle(SpaceShipType);
            _descriptionRowView.DescriptionText = GetDescription(SpaceShipType);
        }   

        private string GetTitle(Entities.SpaceShips.SpaceShipConfigs.SpaceShipType type)
        {
            return type == Entities.SpaceShips.SpaceShipConfigs.SpaceShipType.None ? "" : _staticDataService.GetSpaceShipDescriptor(type).SpaceShipType.ToString();
        }

        private string GetDescription(Entities.SpaceShips.SpaceShipConfigs.SpaceShipType type)
        {
            return type == Entities.SpaceShips.SpaceShipConfigs.SpaceShipType.None ? "" : $"HP: {_staticDataService.GetSpaceShipDescriptor(type).MaxHealth}.\nWeapon slots: {_staticDataService.GetSpaceShipDescriptor(type).WeaponSlotsCount}";
        }
    }
}
