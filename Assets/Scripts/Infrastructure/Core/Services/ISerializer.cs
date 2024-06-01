﻿namespace Assets.Scripts.Infrastructure.Core.Services
{
    public interface ISerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string json);
    }
}
