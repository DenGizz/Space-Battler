using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.HUDs
{
    [RequireComponent(typeof(Button))]
    public class PauseBattleHUD : MonoBehaviour
    {
        private const string PauseButtonText = "II";
        private const string ResumeButtonText = ">";

        private Button button;
        private TextMeshProUGUI buttonText;

        private bool isPaused;

        private void Awake()
        {
            button = GetComponent<Button>();
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = isPaused ? ResumeButtonText : PauseButtonText;
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            isPaused = !isPaused;
            buttonText.text = isPaused ? ResumeButtonText : PauseButtonText;
        }
    }
}
