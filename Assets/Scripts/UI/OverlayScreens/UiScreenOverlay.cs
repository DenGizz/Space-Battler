using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.OverlayScreens
{
    public class UiScreenOverlay : MonoBehaviour
    {
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                gameObject.SetActive(value);
            }
        }

        private bool _isVisible = false;
    }
}
