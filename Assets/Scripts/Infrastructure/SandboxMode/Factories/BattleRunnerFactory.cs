using Assets.Scripts.Battles;
using Zenject;

namespace Assets.Scripts.Infrastructure.SandboxMode.Factories
{
    public class BattleRunnerFactory : IBattleRunnerFactory
    {
        private readonly IInstantiator _instantiator;

        public BattleRunnerFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public BattleRunner CreateBattleRunner(BattleData battleData)
        {
            return _instantiator.Instantiate<BattleRunner>(new[] { battleData });
        }
    }
}
