using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.Services
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
            {
                yield return null;
            }

            // Вызов события после загрузки сцены
            onSceneLoaded?.Invoke();
        }
    }
}
