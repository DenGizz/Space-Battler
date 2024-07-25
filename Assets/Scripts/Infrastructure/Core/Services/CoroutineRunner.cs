using System;
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

        public Coroutine FadeValue(Func<float> getter, Action<float> setter, float targetValue, float time)
        {
            return StartCoroutine(FadeCoroutine(getter, setter, targetValue, time));
        }

        private IEnumerator FadeCoroutine(Func<float> getter, Action<float> setter, float targetValue, float time)
        {
            float beginTime = Time.time;
            float endTime = beginTime + time;
            yield return true;

            while(Time.time <= endTime)
            {
                float value = getter();
                float newValue = Mathf.Lerp(value, targetValue, (Time.time - beginTime) / (endTime - beginTime));
                setter(newValue);
                yield return true;
            }

            yield return false;
        }
    }

    public class CoroutineRunnerComponent : MonoBehaviour { }
}
