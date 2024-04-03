using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _startBattleButton;

        public event Action OnStartBattleButtonClicked;

        private void Awake()
        {
            _startBattleButton.onClick.AddListener(OnStartBattleButtonClick);
        }

        private void OnStartBattleButtonClick()
        {
            OnStartBattleButtonClicked?.Invoke();
        }
    }
}
