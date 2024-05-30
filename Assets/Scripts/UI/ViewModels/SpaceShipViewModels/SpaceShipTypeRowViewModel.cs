using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using Assets.Scripts.UI.ViewModels.SpaceShipViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.NewUi
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
