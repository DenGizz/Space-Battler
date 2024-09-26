using Assets.Scripts.Infrastructure.Ui.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.PopoutMessages
{
    public class PopoutMessagesContainerViewModel : MonoBehaviour
    {
        [SerializeField] private Transform _messagesContainer;
        [SerializeField] private float _messageDisplayTime = 3f;
        [SerializeField] private int _maxMessages = 2;

        private IUiElementsFactory _uiElementsFactory;

        [Inject]
        public void Construct(IUiElementsFactory uiElementsFactory)
        {
            _uiElementsFactory = uiElementsFactory;
        }

        public void ShowMessage(string message)
        {
            if (_messagesContainer.childCount >= _maxMessages)
                Destroy(_messagesContainer.GetChild(0).gameObject);

            CreateMessage(message);
        }

        private void CreateMessage(string message)
        {
            PopoutMessageViewModel messageViewModel = _uiElementsFactory.CreatePopoutMessage();
            messageViewModel.transform.SetParent(_messagesContainer);
            messageViewModel.SetMessage(message);
            Destroy(messageViewModel.gameObject, _messageDisplayTime);
        }
    }
}
