using UnityEngine;

namespace Assets.Scripts.Infrastructure.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "ScenesConfig", menuName = "Config/ScenesConfig")]
    public class ScenesConfig : ScriptableObject
    {
        public string BattleFieldSceneName => _battleFieldSceneName;
        public string MainMenuSceneName => _mainMenuSceneName;

        [SerializeField] private string _battleFieldSceneName;
        [SerializeField] private string _mainMenuSceneName;
    }
}
