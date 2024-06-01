using System;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface ISceneLoader
    {
        public void LoadSceneAsync(string sceneName, Action onSceneLoaded);
    }
}
