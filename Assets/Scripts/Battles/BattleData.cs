using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.SpaceShips;

namespace Assets.Scripts.Battles
{
    public class BattleData
    {
        public ISpaceShip PlayerSpaceShip { get; }
        public ISpaceShip EnemySpaceShip { get;}
        public ICombatAi PlayerCombatAi { get; }
        public ICombatAi EnemyCombatAi { get; }

        public BattleData( ISpaceShip playerSpaceShip, ISpaceShip enemySpaceShip, ICombatAi playerCombatAi, ICombatAi enemyCombatAi)
        {
            PlayerSpaceShip = playerSpaceShip;
            EnemySpaceShip = enemySpaceShip;
            PlayerCombatAi = playerCombatAi;
            EnemyCombatAi = enemyCombatAi;
        }
    }
}
