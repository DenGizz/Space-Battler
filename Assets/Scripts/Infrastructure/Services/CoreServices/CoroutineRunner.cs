using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Unity.Collections.Unicode;

namespace Assets.Scripts.Infrastructure.Services
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
