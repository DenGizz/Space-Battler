using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.UI.PopoutMessages;
using UnityEngine;

public class PopoutMessagesUiScreenOverlay : MonoBehaviour
{
    [SerializeField] private PopoutMessagesContainerViewModel _popoutMessagesContainerViewModel;

    public void ShowMessage(string message)
    {
        _popoutMessagesContainerViewModel.ShowMessage(message);
    }
}