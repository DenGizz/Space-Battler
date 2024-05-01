using Assets.Scripts.Battles;
using UnityEngine;

namespace Assets.Scripts.UI.BattleUI
{
    public class BattleView : MonoBehaviour
    {
        private BattleData _battleData;



        [SerializeField] private HealthView _playerHealthView;
        [SerializeField] private HealthView _enemyHealthView;




        public void Setup(BattleData battleData)
        {
            _battleData = battleData;
            _playerHealthView.Setup(battleData.PlayerSpaceShip);
            _enemyHealthView.Setup(battleData.EnemySpaceShip);
        }



    }
}
