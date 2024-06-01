using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.UI.ViewModels.WeaponViewModels;
using Zenject;

namespace Assets.Scripts.UI.ViewModels.ItemSelectionViewModels
{
    public class SelectWeaponPanelViewModel : SelectItemPanelViewModel<WeaponTypeRowViewModel>
    {
        private IUiElementsFactory _uiFactory;
        private IStaticDataService _staticDataService;

        [Inject]
        public void Construct(IUiElementsFactory uiFactory, IStaticDataService staticDataService)
        {
            _uiFactory = uiFactory;
            _staticDataService = staticDataService;
        }

        protected override IEnumerable<WeaponTypeRowViewModel> CreateContent()
        {
            var content = new List<WeaponTypeRowViewModel>();
            IEnumerable<WeaponDescriptor> allWeaponDescriptors = _staticDataService.GetWeaponDescriptors();

            foreach (var descriptor in allWeaponDescriptors)
            {
                WeaponTypeRowViewModel view = null;// _uiFactory.CreateWeaponTypeWithDescriptionView();
                view.WeaponType = descriptor.WeaponType;
                content.Add(view);
            }

            return content;
        }
    }
}
