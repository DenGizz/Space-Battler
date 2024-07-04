namespace Assets.Scripts.Infrastructure.Localization
{
    public interface ILocalizationDb
    {
        string GetString(string stringKey, LanguageKey selectedLanguage);
    }
}