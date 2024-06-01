using System;
using System.Collections.Generic;
using Assets.Scripts.UI.ViewModels.BaseViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.ViewModels.ItemSelectionViewModels
{
    public abstract class SelectItemPanelViewModel<TViewModel> : MonoBehaviour where TViewModel : MonoBehaviour
    {
        public event Action OnCloseButtonClicked;
        public event Action<TViewModel> OnItemSelected;

        [SerializeField] private Button _closeButton;
        [SerializeField] private Transform _contentContainer;

        private List<TViewModel> _content;

        protected abstract IEnumerable<TViewModel> CreateContent();

        private void Start()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClickedHandler);
            _content = new List<TViewModel>(CreateContent());
            SubscribeToContentClick();
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClickedHandler);
            UnSubscribeContentClick();
        }

        private void SubscribeToContentClick()
        {
            foreach (var item in _content)
            {
                var clickableView = item.GetComponent<ClickableView>();
                clickableView.OnClicked += OnContentClickedHandler;
            }
        }

        private void UnSubscribeContentClick()
        {
            foreach (var item in _content)
            {
                var clickableView = item.GetComponent<ClickableView>();
                clickableView.OnClicked -= OnContentClickedHandler;
            }
        }

        private void OnContentClickedHandler(ClickableView item)
        {
            var clickedItem = item.GetComponent<TViewModel>();

            if(clickedItem == null)
                throw new Exception($"Clicked item is not of type {typeof(TViewModel).Name}");

            OnItemSelected?.Invoke(clickedItem);
        }

        private void OnCloseButtonClickedHandler()
        {
            OnCloseButtonClicked?.Invoke();
        }
    }
}
