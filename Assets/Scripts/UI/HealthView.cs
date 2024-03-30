using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Units;
using UnityEngine;

[AddComponentMenu("UI/HealthView")]
public class HealthView : MonoBehaviour
{
    private ISpaceShip _spaceShip;
    [SerializeField] private GameObject _healthGreenRow;


    public void SetupView(ISpaceShip spaceShip)
    {
        _spaceShip = spaceShip;
    }

    private void LateUpdate()
    {
        if (_spaceShip == null)
            return;

        _healthGreenRow.transform.localScale = new Vector3(_spaceShip.HealthAttribute.HP / _spaceShip.HealthAttribute.BaseHP, 1, 1);
    }
}
