namespace Assets.Scripts.Infrastructure.Core.Services
{
    public interface IFileSystem
    {
        void CreateTextFile(string relativePath, string fileName);
        string ReadTextFile(string relativeFilePath);
        bool IsFileExist(string relativeFilePath);
        bool IsFileEmpty(string relativeFilePath);
        void OverwriteTextFile(string relativeFilePath, string content);
    }
}
