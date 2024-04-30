namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface ISerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string json);
    }
}
