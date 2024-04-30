using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Entities.SpaceShips;

namespace Assets.Scripts.Battles
{
    public class Battle
    {
        public BattleData BattleData { get; }
        public bool IsBattleActive { get; private set; }
        public ISpaceShip Winner { get; set; }

        public Battle(ISpaceShip playerSpaceShip, ISpaceShip enemySpaceShip, ICombatAi playerAi, ICombatAi enemyAi)
        {
            BattleData = new BattleData(playerSpaceShip, enemySpaceShip, playerAi, enemyAi);
        }

        public void StartBattle()
        {
            BattleData.PlayerCombatAi.SetTarget(BattleData.EnemySpaceShip);
            BattleData.EnemyCombatAi.SetTarget(BattleData.PlayerSpaceShip);

            BattleData.PlayerCombatAi.StartCombat();
            BattleData.EnemyCombatAi.StartCombat();

            IsBattleActive = true;
        }

        public void StopBattle()
        {
            BattleData.PlayerCombatAi.StopCombat();
            BattleData.EnemyCombatAi.StopCombat();

            IsBattleActive = false;
        }

        public void ResumeBattle()
        {
            BattleData.PlayerCombatAi.StartCombat();
            BattleData.EnemyCombatAi.StartCombat();

            IsBattleActive = true;
        }
    }
}
