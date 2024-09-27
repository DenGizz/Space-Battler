using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Ui.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
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
        private ICoroutineRunner _coroutineRunner;

        private List<PopoutMessageViewModel> _messages = new List<PopoutMessageViewModel>();

        [Inject]
        public void Construct(IUiElementsFactory uiElementsFactory, ICoroutineRunner coroutineRunner)
        {
            _uiElementsFactory = uiElementsFactory;
            _coroutineRunner = coroutineRunner;
        }

        public void ShowMessage(string messageText)
        {
            if (_messagesContainer.childCount >= _maxMessages)
                Destroy(_messagesContainer.GetChild(0).gameObject);

            PopoutMessageViewModel message = CreateMessage(messageText);
            CloseMessageDelayed(message, _messageDisplayTime);
        }

        private PopoutMessageViewModel CreateMessage(string message)
        {
            PopoutMessageViewModel messageViewModel = _uiElementsFactory.CreatePopoutMessage();
            messageViewModel.transform.SetParent(_messagesContainer);
            messageViewModel.SetMessage(message);
            _messages.Add(messageViewModel);
            return messageViewModel;
        }

        private void CloseMessage(PopoutMessageViewModel message)
        {
            _messages.Remove(message);
            Destroy(message.gameObject);
        }

        private void CloseMessageDelayed(PopoutMessageViewModel message, float delay = 0)
        {
            _coroutineRunner.DoAfterDelay(() => CloseMessage(message), delay);
        }
    }
}
