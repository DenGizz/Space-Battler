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
        [SerializeField] private string _stringKey;

        private ILocalizationService _localizationService;
        private TextMeshProUGUI _text;

        [Inject]
        public void Construct(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }    

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            LocalizeText();
            _localizationService.LanguageSelected += OnLanguageSelectedEventHandler;
        }

        private void OnDestroy()
        {
            _localizationService.LanguageSelected -= OnLanguageSelectedEventHandler;
        }

        private void OnLanguageSelectedEventHandler(LanguageKey key)
        {
            LocalizeText();
        }

        private void LocalizeText()
        {
            if (_stringKey == string.Empty)
            {
                Debug.LogWarning("Cant localize text. No string key.");
                return;
            }
                

            _text.text = _localizationService.GetLocalizedString(_stringKey);
        }
    }
}
