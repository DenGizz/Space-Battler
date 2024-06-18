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
                _selectedOption = value;
                OnOptionSelected?.Invoke(value);
            }
        }

        public TOption DefaultOption { get; set; }

        public event Action<TOption> OnOptionSelected;

        private TOption _selectedOption;

        public void SetOptions(IEnumerable<TOption> options, TOption defaultOption)
        {
            Options = options;
            DefaultOption = defaultOption;
            SelectedOption = defaultOption;
        }
    }
}
