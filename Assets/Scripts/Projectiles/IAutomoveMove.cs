using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    public interface IAutomoveMove
    {
        Vector3 EndPoint { get; set; }
        float Speed { get; set; }
        bool IsMoving { get; set; }
    }
}
