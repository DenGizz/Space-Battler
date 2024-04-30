using Assets.Scripts.Battles;
using UnityEngine;

namespace Assets.Scripts.UI.BattleUI
{
    [AddComponentMenu("UI/BattleUI")]
    public class BattleUI : MonoBehaviour
    {
        private Battle _battle;
        [SerializeField] private BattleView _battleView;

        public void ShowBattleView(Battle battle)
        {
            _battle = battle;
            _battleView.Setup(battle.BattleData);
            _battleView.gameObject.SetActive(true);
        }

        public void HideBattleView()
        {
            _battleView.gameObject.SetActive(false);
        }
    }
}
