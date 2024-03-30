using Assets.Scripts.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IBattleObserver
    {
        public event Action<ICombatUnit> OnWinerDetermined;
    }
}
