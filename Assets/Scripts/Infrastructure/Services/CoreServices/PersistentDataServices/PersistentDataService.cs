using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Services.PersistentDataServices;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.Weapons.WeaponConfigs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Progress;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class PersistentDataService : IPersistentDataService
    {
        private readonly ISerializer _serializer;
        private readonly IFileSystem _fileSystem;

        private const string RelativeSaveDataPath = "SaveData";
        private const string BattleSetupFileName = "BattleSetup.json";
        private const string PlayerProgressFileName = "PlayerProgress.json";

        private PersistentJsonFile _battleSetupDataFile;
        private PersistentJsonFile _playerProgressDataFile;

        public PersistentDataService(ISerializer serializer, IFileSystem fileSystem)
        {
            _serializer = serializer;
            _fileSystem = fileSystem;
        }

        public void Initialize()
        {
            _battleSetupDataFile = new PersistentJsonFile(RelativeSaveDataPath, BattleSetupFileName, _fileSystem);
            _playerProgressDataFile = new PersistentJsonFile(RelativeSaveDataPath, PlayerProgressFileName, _fileSystem);
        }

        public bool IsBattleSetupStored()
        {
           return _battleSetupDataFile.IsDataExist();
        }

        public void SaveBattleSetup(BattleSetup battleSetup)
        {
            string json = _serializer.Serialize(battleSetup);

            SaveOrCreateDataToPersistentFile(_battleSetupDataFile, json);
        }

        public BattleSetup LoadBattleSetup()
        {
            return _serializer.Deserialize<BattleSetup>(_battleSetupDataFile.GetData());
        }

        public bool IsPlayerProgressDataStored()
        {
            return _playerProgressDataFile.IsDataExist();
        }

        public void SavePlayerProgressData(PlayerProgressData playerProgressData)
        {
            string json = _serializer.Serialize(playerProgressData);

            SaveOrCreateDataToPersistentFile(_playerProgressDataFile, json);
        }

        public PlayerProgressData LoadPlayerProgressData()
        {
            return _serializer.Deserialize<PlayerProgressData>(_playerProgressDataFile.GetData());
        }

        private void SaveOrCreateDataToPersistentFile(PersistentJsonFile file, string data)
        {
            if (!file.IsDataExist())
                file.CreateData();

            file.OverwriteData(data);
        }
    }
}
