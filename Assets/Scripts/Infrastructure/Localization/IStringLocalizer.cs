using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Localization
{
    public interface IStringLocalizer
    {
        LanguageKey SelectedLanguage { get; set; }
        event Action<LanguageKey> LanguageSelected;
        string GetLocalizedString(string stringKey);
        string GetLocalizedString(string stringKey, LanguageKey languageKey);
    }
}
