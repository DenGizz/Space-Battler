using UnityEngine;

namespace Assets.Scripts.ExtensionMethods
{
    public static class TransformExtensionMethods
    {
        public static void LookAt2D(this Transform transform, Vector3 target)
        {
            Vector3 dir = target - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
