using Assets.Scripts.UI.BaseUI;
using Assets.Scripts.UI.NewUi.UiElements;
using Assets.Scripts.UI.SelectBattleSetupUI.SpaceShipSetupViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.ViewModels.SlotViewModels
{
    public abstract class ItemSlotViewModel<TOption> : MonoBehaviour
    {
        public IEnumerable<TOption> Options { get; set; }
        public virtual TOption SelectedOption { get; set; }
        public TOption DefaultOption { get; set; }

        public event Action<TOption> OnOptionSelected;

        public void SetOptions(IEnumerable<TOption> options, TOption defaultOption)
        {
            Options = options;
            DefaultOption = defaultOption;
            SelectedOption = defaultOption;
        }
    }
}
