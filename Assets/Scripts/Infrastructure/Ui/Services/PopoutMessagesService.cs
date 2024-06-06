using Assets.Scripts.Infrastructure.Ui.Providers;
using Zenject;

namespace Assets.Scripts.Infrastructure.Ui.Services
{
    public class PopoutMessagesService : IPopoutMessagesService
    {
        private readonly IUisProvider  _uisProvider;

        [Inject]
        public PopoutMessagesService(IUisProvider uiOverlaysProvider)
        {
            _uisProvider = uiOverlaysProvider;
        }

        public void SendMessage(string message)
        {
            _uisProvider.PopoutMessagesOverlay.ShowMessage(message);
        }
    }
}
