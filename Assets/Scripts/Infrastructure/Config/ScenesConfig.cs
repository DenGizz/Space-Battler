using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScenesConfig", menuName = "Config/ScenesConfig")]
public class ScenesConfig : ScriptableObject
{
    public string BattleFieldSceneName => _battleFieldSceneName;

    [SerializeField] private string _battleFieldSceneName;
}
