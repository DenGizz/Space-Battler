using UnityEngine;

namespace Assets.Scripts.Infrastructure.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "ScenesConfig", menuName = "Config/ScenesConfig")]
    public class ScenesConfig : ScriptableObject
    {
        public string SandboxModeSceneName => _sandboxModeSceneName;
        public string MainMenuSceneName => _mainMenuSceneName;

        [SerializeField] private string _sandboxModeSceneName;
        [SerializeField] private string _mainMenuSceneName;
    }
}