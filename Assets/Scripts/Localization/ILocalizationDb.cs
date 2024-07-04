namespace Assets.Scripts.Infrastructure.Localization
{
    public interface ILocalizationDb
    {
        void LoadDb();
        string GetString(string stringKey, LanguageKey selectedLanguage);
    }
}