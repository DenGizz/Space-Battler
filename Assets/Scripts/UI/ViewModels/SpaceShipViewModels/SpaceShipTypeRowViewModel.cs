using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Factories;
using Assets.Scripts.Infrastructure.Localization;
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

        private IStringContentFactory _stringContentFactory;
        private ILocalizationService _localizationService;

        [Inject]
        public void Construct(IStringContentFactory stringContentFactory, ILocalizationService localizationService)
        {
            _stringContentFactory = stringContentFactory;
            _localizationService = localizationService;
        }

        private void Awake()
        {
            _descriptionRowView = GetComponent<DescriptionRowView>();
            _localizationService.LanguageSelected += OnLanguageChangedEventHandler;
        }

        private void OnDestroy()
        {
            _localizationService.LanguageSelected -= OnLanguageChangedEventHandler;
        }

        private void UpdateDescription()
        {
            _descriptionRowView.TitleText = _stringContentFactory.CreateSpaceShipName(SpaceShipType);
            _descriptionRowView.DescriptionText = _stringContentFactory.CreateSpaceShipDescription(SpaceShipType);
        }

        private void ClearView()
        {
            _descriptionRowView.TitleText = string.Empty;
            _descriptionRowView.DescriptionText = string.Empty;
        }

        private void OnLanguageChangedEventHandler(LanguageKey key)
        {
            UpdateDescription();
        }
    }
}
