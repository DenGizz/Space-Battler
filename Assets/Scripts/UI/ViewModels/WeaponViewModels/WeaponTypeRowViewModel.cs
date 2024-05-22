using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using UnityEngine;

namespace Assets.Scripts.UI.WeaponViews
{
    [RequireComponent(typeof(DescriptionRowView))]
    public class WeaponTypeRowViewModel : WeaponTypeViewModel
    {
        private DescriptionRowView _descriptionRowView;

        private void Awake()
        {
            _descriptionRowView = GetComponent<DescriptionRowView>();
        }

        override protected void UpdateView()
        {
            base.UpdateView();
            if (WeaponType == Entities.Weapons.WeaponConfigs.WeaponType.None)
            {
                _descriptionRowView.TitleText = "";
                _descriptionRowView.DescriptionText = "";
                return;
            }

            WeaponDescriptor descriptor = _staticDataService.GetWeaponDescriptor(WeaponType);
            _descriptionRowView.TitleText = descriptor.WeaponType.ToString();
            _descriptionRowView.DescriptionText = $"Damage: {descriptor.Damage}.\nCold down: {descriptor.ColdDownTime} sec.";
        }
    }
}
