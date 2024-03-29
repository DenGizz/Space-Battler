using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthAttribute
{
    float BaseHP { get; }
    float HP { get; }

    void TakeDamage(float damageAmount);
    void RestoreHP(float restoreAmount);
}
