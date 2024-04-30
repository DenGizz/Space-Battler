using Newtonsoft.Json;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    internal class NewtonJsonSerializer : ISerializer
    {
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}