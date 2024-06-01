using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.UI.SelectionPanels;
using Assets.Scripts.UI.WeaponViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Ui.Factories;
using Zenject;

namespace Assets.Scripts.UI.NewUi.ItemSelectionViewModels
{
    public class SelectSpaceShipPanelViewModel : SelectItemPanelViewModel<SpaceShipTypeRowViewModel>
    {
        private IUiElementsFactory _uiFactory;
        private IStaticDataService _staticDataService;

        [Inject]
        public void Construct(IUiElementsFactory uiFactory, IStaticDataService staticDataService)
        {
            _uiFactory = uiFactory;
            _staticDataService = staticDataService;
        }

        protected override IEnumerable<SpaceShipTypeRowViewModel> CreateContent()
        {
            var content = new List<SpaceShipTypeRowViewModel>();
            IEnumerable<SpaceShipDescriptor> allWeaponDescriptors = _staticDataService.GetSpaceShipDescriptors();

            foreach (var descriptor in allWeaponDescriptors)
            {
                SpaceShipTypeRowViewModel view = null;// _uiFactory.CreateWeaponTypeWithDescriptionView();
                view.SpaceShipType = descriptor.SpaceShipType;
                content.Add(view);
            }

            return content;
        }
    }
}
