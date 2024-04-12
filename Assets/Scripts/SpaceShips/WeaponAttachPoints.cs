using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachPoints : MonoBehaviour
{
    public IEnumerable<Transform> AttachmentPoints => _attachmentPoints;

    [SerializeField] private List<Transform> _attachmentPoints;
}
