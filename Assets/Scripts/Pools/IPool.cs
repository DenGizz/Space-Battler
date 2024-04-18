using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Pools
{
    public interface IPool<T>
    {
        T Get();
        void Release(T element);
    }
}