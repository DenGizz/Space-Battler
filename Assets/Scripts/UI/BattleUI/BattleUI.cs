using System;
using Assets.Scripts.Battles;
using Assets.Scripts.SpaceShips;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [AddComponentMenu("UI/BattleUI")]
    public class BattleUI : MonoBehaviour
    {
        private Battle _battle;
        [SerializeField] private BattleView _battleView;
        [SerializeField] private BattleWinnerUI _battleWinnerUI;

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

        public void ShowWinner(ISpaceShip winner, bool isPlayerWin)
        {
            _battleWinnerUI.gameObject.SetActive(true);
            _battleWinnerUI.SetWinner(winner, isPlayerWin);
        }

        private void Start()
        {
            _battleWinnerUI.gameObject.SetActive(false);
        }
    }
}
