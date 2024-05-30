using Assets.Scripts.Infrastructure.UiInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.NewUi.UiElements
{
    public class WindowPanel : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Transform _contentContainer;

        private IUiWindowsService _uiWindowsService;

        public event Action OnCloseButtonClicked;

        [Inject]
        public void Construct(IUiWindowsService uiWindowsService)
        {
            _uiWindowsService = uiWindowsService;
        }

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClickedHandler);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
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
    }
}
