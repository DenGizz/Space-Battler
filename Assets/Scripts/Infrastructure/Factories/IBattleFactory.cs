using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IBattleFactory
    {
        Battle CreateBattle(ISpaceShip playerSpaceShip, ISpaceShip enemySpaceShip);
    }
}
