using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Battles;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

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
