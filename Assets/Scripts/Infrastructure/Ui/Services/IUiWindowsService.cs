using Assets.Scripts.UI.UiElements;

namespace Assets.Scripts.Infrastructure.Ui.Services
{
    public interface IUiWindowsService
    {
        WindowPanel OpenWindow();
        void CloseWindow(WindowPanel window);
        bool IsWindowOpen(WindowPanel window);
    }
}
