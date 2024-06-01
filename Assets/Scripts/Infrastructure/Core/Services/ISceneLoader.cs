using System;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public interface ISceneLoader
    {
        public void LoadSceneAsync(string sceneName, Action onSceneLoaded);
    }
}
