using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.ViewModels.SlotViewModels
{
    public abstract class SelectOptionViewModel<TOption> : MonoBehaviour
    {
        public IEnumerable<TOption> Options { get; set; }

        public virtual TOption SelectedOption
        {
            get => _selectedOption;
            set
            {
                SelectOption(value);
            }
        }

        public TOption DefaultOption { get; set; }

        public event Action<TOption> OnOptionSelected;

        private TOption _selectedOption;

        public void SetOptions(IEnumerable<TOption> options, TOption defaultOption, TOption selectedOption)
        {
            Options = options;
            DefaultOption = defaultOption;
            SelectedOption = selectedOption;
        }

        private void SelectOption(TOption option)
        {
            if (!Options.Contains(option))
                throw new InvalidOperationException("Option is not in the list of options");

            _selectedOption = option;
            OnOptionSelected?.Invoke(option);
        }
    }
}
