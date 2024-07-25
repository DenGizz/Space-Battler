using Assets.Scripts.Infrastructure.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Unity.VisualScripting.Icons;

namespace Assets.Scripts.Localization
{
    public class LocalizationData
    {
        public Dictionary<LanguageKey, Dictionary<string, string>> language_localization;
    }
}