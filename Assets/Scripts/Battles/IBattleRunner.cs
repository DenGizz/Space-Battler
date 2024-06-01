using System;
using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Battles
{
    public interface IBattleRunner
    {
        BattleData BattleData { get; }
        bool IsRunning { get; set; }

        event EventHandler<BattleEndEventArgs> BattleEnded;

        void AddSpaceShipToAllyTeam(ISpaceShip spaceShip);
        void AddSpaceShipToEnemyTeam(ISpaceShip spaceShip);

        void RemoveSpaceShipFromAllyTeam(ISpaceShip spaceShip);
        void RemoveSpaceShipFromEnemyTeam(ISpaceShip spaceShip);

        void RunBattle();
    }
}
