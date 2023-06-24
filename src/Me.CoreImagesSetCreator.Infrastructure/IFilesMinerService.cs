using Me.CoreImagesSetCreator.Domain.ValueObjects;

namespace Me.CoreImagesSetCreator.Infrastructure
{
    public interface IFilesMinerService
    {
        public IEnumerable<FileLocation> GetAllFiles(FolderLocation folder, string searchPattern = ".");
    }
}