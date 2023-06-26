using Me.CoreImagesSetCreator.Domain.ValueObjects;
using Me.CoreImagesSetCreator.Infrastructure.FilesContainer.DataTree;
using Me.CoreImagesSetCreator.Infrastructure.FilesMine.FilesSearch;

namespace Me.CoreImagesSetCreator.Infrastructure.FilesMine
{
    public interface IFilesMinerService
    {
        public Task<FileTreeNode> GetFiles(FolderBaseData folder, IFilesSearchOptions searchOptions);
    }
}