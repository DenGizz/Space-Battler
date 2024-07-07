using System;
using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Core.Services.PersistentProgressServices;
using Assets.Scripts.Infrastructure.Gameplay.Factories;
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

        public event Action OnReturnMainMenuButtonPressed;

        private IStringContentFactory _stringContentFactory;

        public void SetWinner(BattleResult battleResult)
        {
            _winnerNameText.text = 
                battleResult == BattleResult.AllyTeamWin ? 
                _stringContentFactory.CreateAllyTeamWonText() :
                _stringContentFactory.CreateAllyTeamLostText();
        }

        [Inject]
        public void Construct(IStringContentFactory stringContentFactory)
        {
            _stringContentFactory = stringContentFactory;
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
