using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Localization
{
    public class LocalizationService : ILocalizationService
    {
        public LanguageKey SelectedLanguage
        {
            get => _selectedLanguage;
            set 
            {
                _selectedLanguage = value;
                LanguageSelected?.Invoke(value);
            }
        }

        public event Action<LanguageKey> LanguageSelected;

        private LanguageKey _selectedLanguage = LanguageKey.UA;

        private readonly ILocalizationDb _localizationDb;

        public LocalizationService(ILocalizationDb localizationDb)
        {
            _localizationDb = localizationDb;
        }

        public string GetLocalizedString(string stringKey)
        {
            return _localizationDb.GetString(stringKey, SelectedLanguage);
        }

        public string GetLocalizedString(string stringKey, LanguageKey languageKey)
        {
            return _localizationDb.GetString(stringKey, languageKey);
        }
    }
}
