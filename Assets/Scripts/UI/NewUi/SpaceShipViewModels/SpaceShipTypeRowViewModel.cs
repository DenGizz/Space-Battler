using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Assets.Scripts.UI.NewUi
{
    [RequireComponent(typeof(DescriptionRowView))]
    public class SpaceShipTypeRowViewModel : SpaceShipTypeViewModel
    {
        private DescriptionRowView _descriptionRowView;

        private void Awake()
        {
            _descriptionRowView = GetComponent<DescriptionRowView>();
        }

        override protected void UpdateView()
        {
            base.UpdateView();
            if (SpaceShipType == Entities.SpaceShips.SpaceShipConfigs.SpaceShipType.None)
            {
                _descriptionRowView.TitleText = "";
                _descriptionRowView.DescriptionText = "";
                return;
            }

            SpaceShipDescriptor descriptor = _staticDataService.GetSpaceShipDescriptor(SpaceShipType);
            _descriptionRowView.TitleText = descriptor.SpaceShipType.ToString();
            _descriptionRowView.DescriptionText = $"HP: {descriptor.MaxHealth}\nWeapon slots: {descriptor.WeaponSlotsCount}";
        }
    }
}
