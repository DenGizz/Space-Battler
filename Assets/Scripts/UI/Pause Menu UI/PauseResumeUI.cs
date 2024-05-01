using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Pause_Menu_UI
{
    public class PauseResumeUI : MonoBehaviour
    {
        public Action OnPauseContinueButtonClicked;

        [SerializeField] private Button _pauseContinueButton;
    
        private void Awake()
        {
            _pauseContinueButton.onClick.AddListener(OnPauseContinueButtonClickedEventHandler);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnPauseContinueButtonClickedEventHandler()
        {
            OnPauseContinueButtonClicked?.Invoke();
        }
    }
}
