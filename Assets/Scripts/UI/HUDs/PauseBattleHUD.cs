using Assets.Scripts.Infrastructure.Core.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.HUDs
{
    public class PauseBattleHUD : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;

        private IGameplayTickService _gameplayTickService;

        [Inject]
        public void Construct(IGameplayTickService gameplayTickService)
        {
            _gameplayTickService = gameplayTickService;
        }

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _gameplayTickService.IsPaused = !_gameplayTickService.IsPaused;
        }
    }
}
