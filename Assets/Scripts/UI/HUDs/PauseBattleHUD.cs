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
        private IGameplayTickService _gameplayTickService;

        [SerializeField] private Button _pauseButton;
        private const string PauseButtonText = "II";
        private const string ResumeButtonText = ">";
        private TextMeshProUGUI buttonText;

        [Inject]
        public void Construct(IGameplayTickService gameplayTickService)
        {
            _gameplayTickService = gameplayTickService;
        }

        private void Awake()
        {
            _gameplayTickService.OnPausedOrResumed += OnGameplayPauserOrResumedEventHandler;

            buttonText = _pauseButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _gameplayTickService.IsPaused ? ResumeButtonText : PauseButtonText;
            _pauseButton.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _gameplayTickService.IsPaused = !_gameplayTickService.IsPaused;
        }

        private void OnGameplayPauserOrResumedEventHandler( object sender, GameplayPauseResumeEventArgs e)
        {
            buttonText.text = e.IsPaused ? ResumeButtonText : PauseButtonText;
        }
    }
}
