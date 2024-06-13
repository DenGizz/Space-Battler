using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.HUDs
{
    public class PauseBattleHUD : MonoBehaviour
    {
        private const string PauseButtonText = "II";
        private const string ResumeButtonText = ">";

        [SerializeField] private Button _pauseButton;

        private IGameplayTickService _gameplayTickService;
        private TextMeshProUGUI buttonText;

        [Inject]
        public void Construct(IGameplayTickService gameplayTickService)
        {
            _gameplayTickService = gameplayTickService;
        }

        private void Awake()
        {
            _gameplayTickService.OnPauseOrResume += OnPausedOrResumed;

            buttonText = _pauseButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _gameplayTickService.IsPaused ? ResumeButtonText : PauseButtonText;
            _pauseButton.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _gameplayTickService.IsPaused = !_gameplayTickService.IsPaused;
        }

        private void OnPausedOrResumed()
        {
            buttonText.text = _gameplayTickService.IsPaused ? ResumeButtonText : PauseButtonText;
        }
    }
}
