using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.WeaponViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.SelectionPanels
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
