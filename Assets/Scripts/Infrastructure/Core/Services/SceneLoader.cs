using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public class SceneLoader : ISceneLoader
    {
        ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadSceneAsync(string sceneName, Action onSceneLoaded)
        {
            _coroutineRunner.StartCoroutine(LoadSceneCoroutine(sceneName, onSceneLoaded));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName, Action onSceneLoaded)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            while (!asyncLoad.isDone)
                yield return null;

            onSceneLoaded?.Invoke();
        }
    }
}
