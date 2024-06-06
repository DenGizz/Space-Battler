using Assets.Scripts.UI.OverlayScreens;

namespace Assets.Scripts.Infrastructure.Ui.Providers
{
    public class UisProvider : IUisProvider
    {
        public UI.Uis.Ui SandboxModeUi { get; set; }
        public UiScreenOverlay LoadingOverlay { get; set; }
        public PopoutMessagesUiScreenOverlay PopoutMessagesOverlay { get; set; }
    }
}
