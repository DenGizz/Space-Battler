using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.NewUi.UiElements
{
    public class WindowPanel : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Transform _contentContainer;

        public event Action OnCloseButtonClicked;

        public void AddContent(GameObject content)
        {
            content.transform.SetParent(_contentContainer);
        }
    }
}
