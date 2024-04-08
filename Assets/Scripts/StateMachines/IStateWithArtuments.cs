namespace Assets.Scripts.StateMachines
{
    public interface IStateWithArtuments<TArgs>
    {
        void Enter(TArgs args);
    }
}
