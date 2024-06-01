using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public class CoroutineRunner : ICoroutineRunner
    {
        private static CoroutineRunnerComponent runner;

        public CoroutineRunner()
        {
            GameObject runnerObject = new GameObject("CoroutineRunner");
            CoroutineRunnerComponent runnerComponent = runnerObject.AddComponent<CoroutineRunnerComponent>();
            GameObject.DontDestroyOnLoad(runnerObject);
            runner = runnerObject.AddComponent<CoroutineRunnerComponent>();
        }

        public Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return runner.StartCoroutine(coroutine);
        }

        public void StopCoroutine(Coroutine coroutine)
        {
            runner.StopCoroutine(coroutine);
        }
    }

    public class CoroutineRunnerComponent : MonoBehaviour { }
}
