using Assets.Scripts.UI.Uis;
using UnityEngine;

namespace Assets.Scripts.UI.UiScreens
{
    public abstract class UiScreen : MonoBehaviour
    {
        public bool IsInitialized { get; private set; }
        public bool IsVisible { get; private set; }

        protected Ui _ui;

        public virtual void Setup(Ui ui)
        {
            if(IsInitialized)
                throw new System.Exception("UiScreen is already initialized");

            _ui = ui ?? throw new System.ArgumentNullException($"{nameof(ui)} in {nameof(Setup)} is null");

            IsInitialized = true;
        }

        public void Show()
        {
            IsVisible = true;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            IsVisible = false;
            gameObject.SetActive(false);
        }
    }
}
