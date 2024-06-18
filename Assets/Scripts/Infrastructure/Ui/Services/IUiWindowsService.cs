using Assets.Scripts.UI.UiElements;

namespace Assets.Scripts.Infrastructure.Ui.Services
{
    public interface IUiWindowsService
    {
        UiWindow OpenWindow();
        void CloseWindow(UiWindow uiWindow);
        bool IsWindowOpen(UiWindow uiWindow);
    }
}
