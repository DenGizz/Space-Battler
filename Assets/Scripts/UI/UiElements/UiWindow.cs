using System;
using Assets.Scripts.Infrastructure.Ui.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.UiElements
{
    public class UiWindow : MonoBehaviour
    {
        public event Action OnCloseButtonClicked;

        private IUiWindowsService _uiWindowsService;

        [SerializeField] private Button _closeButton;
        [SerializeField] private Transform _contentContainer;

        [Inject]
        public void Construct(IUiWindowsService uiWindowsService)
        {
            _uiWindowsService = uiWindowsService;
        }

        public void AddContent(GameObject content)
        {
            content.transform.SetParent(_contentContainer);
            content.GetComponent<RectTransform>().sizeDelta = _contentContainer.GetComponent<RectTransform>().sizeDelta;
        }

        private void OnCloseButtonClickedHandler()
        {
            OnCloseButtonClicked?.Invoke();
            _uiWindowsService.CloseWindow(this);
        }

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClickedHandler);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}
