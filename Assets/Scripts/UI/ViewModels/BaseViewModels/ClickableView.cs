using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.BaseUI
{
    public class ClickableView : MonoBehaviour, IPointerClickHandler
    {
        public Action<ClickableView> OnClicked;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke(this);
        }
    }
}
