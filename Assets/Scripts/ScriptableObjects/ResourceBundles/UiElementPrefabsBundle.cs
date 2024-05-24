using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UiElementPrefabsBundle", menuName = "ScriptableObjects/ResourceBundles/UiElementPrefabsBundle")]
public class UiElementPrefabsBundle : ScriptableObject
{
    public GameObject SpaceShipHealthViewPrefab => _spaceShipHealthViewPrefab;

    public GameObject WindowPrefab => _windowPrefab;

    [SerializeField] private GameObject _spaceShipHealthViewPrefab;
    [SerializeField] private GameObject _windowPrefab;
}
