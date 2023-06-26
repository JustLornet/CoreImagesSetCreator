using Me.CoreImagesSetCreator.Domain.ValueObjects;
using Me.CoreImagesSetCreator.Infrastructure.FilesContainer.DataTree;
using Me.CoreImagesSetCreator.Infrastructure.FilesMine.FilesSearch;

namespace Me.CoreImagesSetCreator.Infrastructure.FilesMine
{
    public sealed class SimpleFilesMinerService : IFilesMinerService
    {
        private readonly IFilesSearchOptions _nullOptions = new SearchOptionsNullObject();

        public Task<FileTreeNode> GetAllFiles(FolderBaseData folder, IFilesSearchOptions searchOptions)
        {
            var folderInfo = folder.DirectoryInfo;
            var filesDataTask = Task.Run(() =>
            {
                return folderInfo.EnumerateFiles("*", SearchOption.AllDirectories).AsParallel().Where(f => searchOptions.IsFileMatch(f)).Select(f => new FileBaseData(f)).ToList();
            });

            return filesDataTask;
        }
    }
}