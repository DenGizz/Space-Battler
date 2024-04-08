using System;
using Assets.Scripts.Battles;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [AddComponentMenu("UI/BattleUI")]
    public class BattleUI : MonoBehaviour
    {
        private Battle _battle;
        [SerializeField] private BattleView _battleView;

        public void SetBattle(Battle battle)
        {
            _battle = battle;
            _battleView.Setup(battle.BattleData);
        }
    }
}
