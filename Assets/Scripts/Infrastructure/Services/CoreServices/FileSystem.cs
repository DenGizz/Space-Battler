using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.CoreServices
{
    public class FileSystem : IFileSystem
    {
        private string _rootPath => Application.persistentDataPath;

        public void CreateTextFile(string relativePath, string fileName)
        {
            string path = GetFullFilePath(Path.Combine(relativePath, fileName));

            EnsureDirectoryExists(path);

            using (FileStream fs = File.Create(path))
            {
            }
        }

        public string ReadTextFile(string relativeFilePath)
        {
            string path = GetFullFilePath(relativeFilePath);
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        public bool IsFileExist(string relativeFilePath)
        {
            string path = GetFullFilePath(relativeFilePath);
            return File.Exists(path);
        }

        public bool IsFileEmpty(string relativeFilePath)
        {
            string path = GetFullFilePath(relativeFilePath);
            FileInfo fileInfo = new FileInfo(path);

            return fileInfo.Length == 0;
        }

        public void OverwriteTextFile(string relativeFilePath, string content)
        {
            string path = GetFullFilePath(relativeFilePath);
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.Write(content);
            }
        }

        private string GetFullFilePath(string relativeFilePath)
        {
            return Path.Combine(_rootPath, relativeFilePath);
        }

        private void EnsureDirectoryExists(string filePath)
        {
            string directoryPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
