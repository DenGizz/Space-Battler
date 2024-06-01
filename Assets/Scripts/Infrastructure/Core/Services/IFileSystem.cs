namespace Assets.Scripts.Infrastructure.Services.CoreServices
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
