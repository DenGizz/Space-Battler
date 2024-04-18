using Assets.Scripts.Battles;
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
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class PersistentDataService : IPersistentDataService
    {
        private readonly ISerializer _serializer;
        private readonly IFileSystem _fileSystem;

        private const string RelativeSaveDataPath = "SaveData";
        private const string BattleSetupFileName = "BattleSetup.json";

        public PersistentDataService(ISerializer serializer, IFileSystem fileSystem)
        {
            _serializer = serializer;
            _fileSystem = fileSystem;
        }

        public void SaveBattleSetup(BattleSetup battleSetup)
        {
            string json = _serializer.Serialize(battleSetup);
            string path = GetBattleSetupSaveFilePath();
            SaveToFile(path, json);
        }

        public BattleSetup LoadBattleSetup()
        {
            string path = GetBattleSetupSaveFilePath();

            if (!_fileSystem.IsFileExist(path))
                return null;

            string json = LoadFromFile(path);
            return _serializer.Deserialize<BattleSetup>(json);
        }

        private void SaveToFile(string path, string content)
        {
            if (!_fileSystem.IsFileExist(path))
                _fileSystem.CreateTextFile(RelativeSaveDataPath,BattleSetupFileName );

            _fileSystem.OverwriteTextFile(path, content);
        }

        private string LoadFromFile(string path)
        {
            return _fileSystem.ReadTextFile(path);
        }

        private string GetBattleSetupSaveFilePath()
        {
            return Path.Combine(RelativeSaveDataPath, BattleSetupFileName);
        }
    }
}
