using Assets.Scripts.UI.OverlayScreens;

namespace Assets.Scripts.Infrastructure.Ui.Factories
{
    public interface IUiFactory
    {
        UI.Uis.Ui CreateMainMenuUi();
        UI.Uis.Ui CreateSandboxBattleUi();

        UiScreenOverlay CreateLoadingOverlay();
        PopoutMessagesUiScreenOverlay CreatePopoutMessagesOverlay();
        ChangeLanguageUiScreenOverlay CreateChangeLanguageUiScreenOverlay();
    }
}
