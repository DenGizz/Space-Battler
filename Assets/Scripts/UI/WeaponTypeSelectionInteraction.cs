using Assets.Scripts.Entities.Weapons.WeaponConfigs;
using Assets.Scripts.UI.ViewModels.ItemSelectionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    internal class WeaponTypeSelectionInteraction : ItemSelectionWindowInteraction<WeaponType>
    {
        protected override IEnumerable<MonoBehaviour> CreateViewsForSlotOptions(IEnumerable<WeaponType> options)
        {
            throw new NotImplementedException();
        }

        protected override WeaponType GetOptionFromView(MonoBehaviour view)
        {
            throw new NotImplementedException();
        }
    }
}
