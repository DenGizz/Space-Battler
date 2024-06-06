using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.PopoutMessages
{
    public class PopoutMessageViewModel : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _messageText;

        public void SetMessage(string message)
        {
            _messageText.text = message;
        }
    }
}
