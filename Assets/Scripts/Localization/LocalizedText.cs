using Assets.Scripts.Infrastructure.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Localization
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizedText : MonoBehaviour
    {
        private IStringLocalizer _stringLocalizer;
        private TextMeshProUGUI _text;
        private string stringKey;

        [Inject]
        public void Construct(IStringLocalizer stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }    

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            stringKey = _text.text;
            LocalizeText();
            _stringLocalizer.LanguageSelected += OnLanguageSelectedEventHandler;
        }

        private void OnDestroy()
        {
            _text.text = stringKey;
        }

        private void OnLanguageSelectedEventHandler(LanguageKey key)
        {
            LocalizeText();
        }

        private void LocalizeText()
        {
            _text.text = _stringLocalizer.GetLocalizedString(stringKey);
        }
    }
}
