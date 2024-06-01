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

        private IBattleTickService _battleTickService;
        private TextMeshProUGUI buttonText;

        [Inject]
        public void Construct(IBattleTickService battleTickService)
        {
            _battleTickService = battleTickService;
        }

        private void Awake()
        {
            _battleTickService.OnPauseOrResume += OnPausedOrResumed;

            buttonText = _pauseButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _battleTickService.IsPaused ? ResumeButtonText : PauseButtonText;
            _pauseButton.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _battleTickService.IsPaused = !_battleTickService.IsPaused;
        }

        private void OnPausedOrResumed()
        {
            buttonText.text = _battleTickService.IsPaused ? ResumeButtonText : PauseButtonText;
        }
    }
}
