using Assets.Scripts.Battles;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Weapons.WeaponConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class PersistentDataService : IPersistentDataService
    {
        //TODO: Mock implementation. Replace with real implementation

        public void SaveBattleSetup(BattleSetup battleSetup)
        {
            SpaceShipSetup playerSetup = battleSetup.PlayerSetup;
            SpaceShipSetup enemySetup = battleSetup.EnemySetup;

            PlayerPrefs.SetInt("Player_SpaceShip", (int)playerSetup.SpaceShipType);
            PlayerPrefs.SetInt("Player_WeaponCount", playerSetup.WeaponTypes.Count);

            for (int i = 0; i < playerSetup.WeaponTypes.Count; i++)
                PlayerPrefs.SetInt($"Player_Weapon_{i}", (int)playerSetup.WeaponTypes[i]);

            PlayerPrefs.SetInt("Enemy_SpaceShip", (int)enemySetup.SpaceShipType);
            PlayerPrefs.SetInt("Enemy_WeaponCount", enemySetup.WeaponTypes.Count);

            for (int i = 0; i < enemySetup.WeaponTypes.Count; i++)
                PlayerPrefs.SetInt($"Enemy_Weapon_{i}", (int)enemySetup.WeaponTypes[i]);
        }

        public BattleSetup LoadBattleSetup()
        {
            int playerSpaceShip = PlayerPrefs.GetInt("Player_SpaceShip");
            int playerWeaponCount = PlayerPrefs.GetInt("Player_WeaponCount");
            int[] playerWeapons = new int[playerWeaponCount];

            for (int i = 0; i < playerWeaponCount; i++)
                playerWeapons[i] = PlayerPrefs.GetInt($"Player_Weapon_{i}");

            SpaceShipType playerSpaceShipType = (SpaceShipType)playerSpaceShip;
            List<WeaponType> playerWeaponTypes = playerWeapons.Select(w => (WeaponType)w).ToList();

            SpaceShipSetup playerSetup = new SpaceShipSetup(playerSpaceShipType, playerWeaponTypes);

            int enemySpaceShip = PlayerPrefs.GetInt("Enemy_SpaceShip");
            int enemyWeaponCount = PlayerPrefs.GetInt("Enemy_WeaponCount");
            int[] enemyWeapons = new int[enemyWeaponCount];

            for (int i = 0; i < enemyWeaponCount; i++)
                enemyWeapons[i] = PlayerPrefs.GetInt($"Enemy_Weapon_{i}");

            SpaceShipType enemySpaceShipType = (SpaceShipType)enemySpaceShip;
            List<WeaponType> enemyWeaponTypes = enemyWeapons.Select(w => (WeaponType)w).ToList();

            SpaceShipSetup enemySetup = new SpaceShipSetup(enemySpaceShipType, enemyWeaponTypes);

            return new BattleSetup(playerSetup, enemySetup);
        }
    }
}
