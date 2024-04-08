using System;
using UnityEngine;

namespace Assets.Scripts.UI.BaseUI
{
    public class DescriptionRowView : MonoBehaviour
    {
        public string TitleText
        {
            get => _titleText.text;
            set => _titleText.text = value;
        }

        public string DescriptionText
        {
            get => _descriptionText.text;
            set => _descriptionText.text = value;
        }

        public Sprite Sprite
        {
            get => _spriteView.Sprite;
            set => _spriteView.Sprite = value;
        }

        public event Action<DescriptionRowView> OnClick;

        [SerializeField] private TMPro.TextMeshProUGUI _titleText;
        [SerializeField] private TMPro.TextMeshProUGUI _descriptionText;
        [SerializeField] private SpriteView _spriteView;

    }
}
