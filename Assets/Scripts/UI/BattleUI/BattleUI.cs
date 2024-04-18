using System;
using Assets.Scripts.Battles;
using Assets.Scripts.SpaceShips;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
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
