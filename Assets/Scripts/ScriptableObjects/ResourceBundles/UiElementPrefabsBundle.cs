using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UiElementPrefabsBundle", menuName = "ScriptableObjects/ResourceBundles/UiElementPrefabsBundle")]
public class UiElementPrefabsBundle : ScriptableObject
{
    public GameObject SpaceShipHealthViewPrefab => _spaceShipHealthViewPrefab;

    [SerializeField] private GameObject _spaceShipHealthViewPrefab;
}
