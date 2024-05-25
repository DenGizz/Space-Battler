using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.UI.ViewModels.ItemSelectionViewModels;
using Assets.Scripts.UI.WeaponViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class WeaponTypeSelectionInteraction : ItemSelectionWindowInteraction<WeaponType>
    {
        private IUiElementsFactory _uiElementsFactory;

        protected override IEnumerable<MonoBehaviour> CreateViewsForSlotOptions(IEnumerable<WeaponType> options)
        {
            List<WeaponTypeRowViewModel> views = new List<WeaponTypeRowViewModel>();

            foreach (var option in options)
            {
                WeaponTypeRowViewModel view = _uiElementsFactory.CreateWeaponTypeRowView();
                view.WeaponType = option;
                views.Add(view);
            }

            return views;
        }

        protected override WeaponType GetOptionFromView(MonoBehaviour view)
        {
            return (view as WeaponTypeRowViewModel).WeaponType;
        }
    }
}
