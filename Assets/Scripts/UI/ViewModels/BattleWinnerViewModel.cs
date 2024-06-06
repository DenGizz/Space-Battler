using System;
using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Core.Services.PersistentProgressServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.ViewModels
{
    public class BattleWinnerViewModel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _winnerNameText;
        [SerializeField] private Button _returnToMainMenuButton;

        [SerializeField] string winText = "Ally team won";
        [SerializeField] string loseText = "Ally team lost";

        public event Action OnReturnMainMenuButtonPressed;

        public void SetWinner(BattleResult battleResult)
        {
            _winnerNameText.text = battleResult == BattleResult.AllyTeamWin ? winText : loseText;
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
