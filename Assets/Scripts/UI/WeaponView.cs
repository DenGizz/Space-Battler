using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    public Image WeaponImage => _weaponImage;

    [SerializeField] private Image _weaponImage;
}
