using Assets.Scripts.Battles;
using UnityEngine;

namespace Assets.Scripts.UI.BattleUI
{
    [AddComponentMenu("UI/BattleUI")]
    public class BattleUI : MonoBehaviour
    {
        private BattleData _battleData;
        [SerializeField] private BattleView _battleView;

        public void ShowBattleView(BattleData battleData)
        {
            _battleData = battleData;
            _battleView.SetBattleData(battleData);
            _battleView.gameObject.SetActive(true);
        }

        public void HideBattleView()
        {
            _battleView.gameObject.SetActive(false);
        }
    }
}
