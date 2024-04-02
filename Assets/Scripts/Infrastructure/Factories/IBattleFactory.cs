using Assets.Scripts.SpaceShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IBattleFactory
    {
        BattleData CreateBattleForSpaceShips(ISpaceShip player, ISpaceShip enemy);
    }
}
