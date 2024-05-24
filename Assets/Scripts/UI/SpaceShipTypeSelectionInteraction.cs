using Assets.Scripts.Entities.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.UI.ViewModels.ItemSelectionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    internal class SpaceShipTypeSelectionInteraction : ItemSelectionWindowInteraction<SpaceShipType>
    {
        protected override IEnumerable<MonoBehaviour> CreateViewsForSlotOptions(IEnumerable<SpaceShipType> options)
        {
            throw new NotImplementedException();
        }

        protected override SpaceShipType GetOptionFromView(MonoBehaviour view)
        {
            throw new NotImplementedException();
        }
    }
}
