using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public interface IDamagableEntity
    {
        void TakeDamage(float damage);
    }
}