using Me.CoreImagesSetCreator.Domain.ValueObjects;

namespace Me.CoreImagesSetCreator.Infrastructure
{
    public sealed class SimpleFilesMinerService : IFilesMinerService
    {
        public IEnumerable<FileLocation> GetAllFiles(FolderLocation folder, string searchPattern = ".")
        {
            var folderInfo = folder.DirectoryInfo;

            return folderInfo.EnumerateFiles(searchPattern, SearchOption.AllDirectories).Select(f => new FileLocation(f));
        }
    }
}