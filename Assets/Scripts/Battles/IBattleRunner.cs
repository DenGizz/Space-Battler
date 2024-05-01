using Assets.Scripts.Battles;
using Assets.Scripts.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public interface IBattleRunner
    {
        BattleData BattleData { get; }

        event EventHandler<BattleEndEventArgs> BattleEnded;

        void AddSpaceShipToAllyTeam(ISpaceShip spaceShip);
        void AddSpaceShipToEnemyTeam(ISpaceShip spaceShip);

        void RemoveSpaceShipFromAllyTeam(ISpaceShip spaceShip);
        void RemoveSpaceShipFromEnemyTeam(ISpaceShip spaceShip);

        void RunBattle();
    }
}
