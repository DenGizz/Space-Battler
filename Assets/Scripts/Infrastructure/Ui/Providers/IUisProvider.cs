using Assets.Scripts.UI.OverlayScreens;

namespace Assets.Scripts.Infrastructure.Ui.Providers
{
    public interface IUisProvider
    {
        UI.Uis.Ui SandboxModeUi { get; set; }

        UiScreenOverlay LoadingOverlay { get; set; }
        PopoutMessagesUiScreenOverlay PopoutMessagesOverlay { get; set; }
    }
}
