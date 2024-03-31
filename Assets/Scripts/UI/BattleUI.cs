using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

[AddComponentMenu("UI/BattleUI")]
public class BattleUI : MonoBehaviour
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
