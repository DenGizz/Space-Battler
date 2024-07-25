using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.UI.OverlayScreens;
using Assets.Scripts.UI.PopoutMessages;
using UnityEngine;

public class PopoutMessagesUiScreenOverlay : UiScreenOverlay
{
    [SerializeField] private PopoutMessagesContainerViewModel _popoutMessagesContainerViewModel;

    public void ShowMessage(string message)
    {
        _popoutMessagesContainerViewModel.ShowMessage(message);
    }
}