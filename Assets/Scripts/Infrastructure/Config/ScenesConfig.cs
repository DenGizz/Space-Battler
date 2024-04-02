using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ScenesConfig", menuName = "Config/ScenesConfig")]
public class ScenesConfig : ScriptableObject
{
    public SceneAsset BattleFieldScene => _battleFieldScene;

    [SerializeField] private SceneAsset _battleFieldScene;
}
