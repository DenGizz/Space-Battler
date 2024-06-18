using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.UI.ViewModels.WeaponViewModels;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI
{
    public class WeaponTypeSelectionInteraction : ItemSelectionWindowInteraction<WeaponType>
    {
        private IUiElementsFactory _uiElementsFactory;

        [Inject]
        public void Construct(IUiElementsFactory uiElementsFactory)
        {
            _uiElementsFactory = uiElementsFactory;
        }

        protected override IEnumerable<MonoBehaviour> CreateViewsForSlotOptions(IEnumerable<WeaponType> options)
        {
            List<WeaponTypeRowViewModel> views = new List<WeaponTypeRowViewModel>();

            foreach (var option in options)
            {
                if(option == WeaponType.None)
                    continue;

                WeaponTypeRowViewModel view = _uiElementsFactory.CreateWeaponTypeRowView();
                view.WeaponType = option;
                views.Add(view);
            }

            return views;
        }

        protected override WeaponType GetOptionFromView(GameObject viewGameObject)
        {
            return viewGameObject.GetComponent<IWeaponTypeViewModel>().WeaponType;
        }
    }
}
