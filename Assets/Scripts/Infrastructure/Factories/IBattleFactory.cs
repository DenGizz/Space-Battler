using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IBattleFactory
    {
        Battle CreateBattle(ISpaceShip playerSpaceShip, ISpaceShip enemySpaceShip);
    }
}
