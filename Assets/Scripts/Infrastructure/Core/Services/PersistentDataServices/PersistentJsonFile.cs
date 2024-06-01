using System;
using System.IO;

namespace Assets.Scripts.Infrastructure.Core.Services.PersistentDataServices
{
    public class PersistentJsonFile
    {
        private readonly string _filePath;
        private readonly string _fileName;
        private readonly string _fullFilePath;

        private readonly IFileSystem _fileSystem;

        public PersistentJsonFile(string filePath, string fileName, IFileSystem fileSystem)
        {
            _filePath = filePath;
            _fileName = fileName;
            _fullFilePath = Path.Combine(_filePath, _fileName);

            _fileSystem = fileSystem;
        }

        public bool IsDataExist()
        {
            return _fileSystem.IsFileExist(_fullFilePath) && !_fileSystem.IsFileEmpty(_fullFilePath);
        }

        public void CreateData()
        {
            if(IsDataExist())
                throw new InvalidOperationException("Data already exists.");

            _fileSystem.CreateTextFile(_filePath, _fileName);
        }

        public void OverwriteData(string data)
        {
            _fileSystem.OverwriteTextFile(_fullFilePath, data);
        }

        public string GetData()
        {
           return _fileSystem.ReadTextFile(_fullFilePath);
        }
    }
}
