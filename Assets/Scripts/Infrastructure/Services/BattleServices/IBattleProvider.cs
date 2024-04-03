using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public interface IBattleProvider
    {
        Battle.Battle CurrentBattle { get; set; }
    }
}
