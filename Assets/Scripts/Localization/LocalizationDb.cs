using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Core.Services.AssetProviders;
using Assets.Scripts.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Localization
{
    public class LocalizationDb : ILocalizationDb
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly ISerializer _serializer;

        private LocalizationData _localizationData;

        public LocalizationDb(IAssetsProvider assetsProvider, ISerializer serializer)
        {
            _assetsProvider = assetsProvider;
            _serializer = serializer;
        }

        public void LoadDb()
        {
            TextAsset localizationAsset = _assetsProvider.GetLocalizationTextAsset();
            _localizationData = _serializer.Deserialize<LocalizationData>(localizationAsset.text);
        }

        public string GetString(string stringKey, LanguageKey selectedLanguage)
        {
            if(_localizationData.language_localization[selectedLanguage].ContainsKey(stringKey))
                return _localizationData.language_localization[selectedLanguage][stringKey];

            return stringKey;
        }
    }
}
