using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factories
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
