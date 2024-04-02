using UnityEngine;

namespace Assets.Scripts.Infrastructure.Config
{
    [CreateAssetMenu(fileName = "ScenesConfig", menuName = "Config/ScenesConfig")]
    public class ScenesConfig : ScriptableObject
    {
        public string BattleFieldSceneName => _battleFieldSceneName;

        [SerializeField] private string _battleFieldSceneName;
    }
}
