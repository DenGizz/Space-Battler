using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.ViewModels.BaseViewModels
{
    public class SpriteView : MonoBehaviour
    {
        public Sprite Sprite
        {
            get => _image.sprite;
            set
            {
                _image.color = value == null ? new Color(0, 0, 0, 0) : Color.white;
                _image.sprite = value;
            }
        }

        [SerializeField] private Image _image;
        [SerializeField] private Sprite _defaultSprite;


#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Application.isPlaying)
                return;

            if (_image == null)
                return;

            Sprite = _defaultSprite;
        }
#endif

    }
}
