using Assets.Scripts.Projectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileDescriptor", menuName = "StaticData/ProjectileDescriptor", order = 1)]
public class ProjectileDescriptor : ScriptableObject
{
    public ProjectileType ProjectileType => _projectileType;
    public float Speed => _speed;
    public Sprite Sprite => _sprite;
    public GameObject Prefab => _prefab;

    [SerializeField] private ProjectileType _projectileType;
    [Tooltip("Unit/sec")]
    [SerializeField] private float _speed;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _prefab;
}
