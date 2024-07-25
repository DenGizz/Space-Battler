using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
        public void StopCoroutine(Coroutine coroutine);

        public Coroutine FadeValue(Func<float> getter, Action<float> setter, float targetValue, float time);
    }
}
