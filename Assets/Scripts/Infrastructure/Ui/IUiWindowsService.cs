using Assets.Scripts.UI.NewUi.UiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Ui
{
    public interface IUiWindowsService
    {
        WindowPanel OpenWindow();
        void CloseWindow(WindowPanel window);
        bool IsWindowOpen(WindowPanel window);
    }
}
