using System;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Services.PersistentProgressServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.BattleUI
{
    public class BattleWinnerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _winnerNameText;
        [SerializeField] private TextMeshProUGUI _winLoseStatisticText;
        [SerializeField] private Button _returnToMainMenuButton;

        [SerializeField] string winText = "You win!";
        [SerializeField] string loseText = "You lose!";

        public event Action OnReturnMainMenuButtonPressed;

        private IProgressProvider _progressProvider;

        [Inject]
        public void Construct(IProgressProvider progressProvider)
        {
            _progressProvider = progressProvider;
        }

        public void SetWinner(ISpaceShip winnerSpaceShip, bool isPlayerWin)
        {
            _winnerNameText.text = isPlayerWin ? winText : loseText;
            _winLoseStatisticText.text = $"Wins: {_progressProvider.PlayerProgressData.BattlesWon}. Loses: {_progressProvider.PlayerProgressData.BattlesLost}";
        }

        private void Awake()
        {
            _returnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonButtonPressed);
        }

        private void OnReturnToMainMenuButtonButtonPressed()
        {
            OnReturnMainMenuButtonPressed?.Invoke();
        }

        private void OnDestroy()
        {
            _returnToMainMenuButton.onClick.RemoveListener(OnReturnToMainMenuButtonButtonPressed);
        }
    }
}
