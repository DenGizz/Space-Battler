using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.ViewModels.SpaceShipViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.Ui.Factories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI
{
    public class SpaceShipTypeSelectionInteraction : ItemSelectionWindowInteraction<SpaceShipType>
    {
        private IUiElementsFactory _uiElementsFactory;

        [Inject]
        public void Construct(IUiElementsFactory uiElementsFactory)
        {
            _uiElementsFactory = uiElementsFactory;
        }

        protected override IEnumerable<MonoBehaviour> CreateViewsForSlotOptions(IEnumerable<SpaceShipType> options)
        {
            List<SpaceShipTypeRowViewModel> views = new List<SpaceShipTypeRowViewModel>();

            foreach (var option in options)
            {
                SpaceShipTypeRowViewModel view = _uiElementsFactory.CreateSpaceShipTypeRowView();
                view.SpaceShipType = option;
                views.Add(view);
            }

            return views;
        }

        protected override SpaceShipType GetOptionFromView(GameObject viewGameObject)
        {
            return viewGameObject.GetComponent<ISpaceShipViewModel>().SpaceShipType;
        }
    }
}
