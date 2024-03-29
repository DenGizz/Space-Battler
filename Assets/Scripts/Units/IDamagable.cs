using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public interface IDamagable
    {
        void TakeDamage(float damageAmount);
    }
}