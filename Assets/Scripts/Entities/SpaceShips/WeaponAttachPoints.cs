using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entities.SpaceShips
{
    public class WeaponAttachPoints : MonoBehaviour
    {
        public IEnumerable<Transform> AttachmentPoints => _attachmentPoints;

        [SerializeField] private List<Transform> _attachmentPoints;
    }
}
