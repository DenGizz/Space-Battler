namespace Assets.Scripts.Pools
{
    public interface IPool<T>
    {
        T Get();
        void Release(T element);
        void Clear();
    }
}