using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
        public void StopCoroutine(Coroutine coroutine);
    }
}
