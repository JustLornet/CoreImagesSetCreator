using Me.CoreImagesSetCreator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Infrastructure.FilesContainer.DataTree
{
    public class FileTreeNode
    {
        private Dictionary<string, FileBaseData> _files = new();
        private Dictionary<string, FileTreeNode> _subNodes = new();

        private FolderBaseData _currentFolder;

        public FileTreeNode(FolderBaseData folder)
        {
                _currentFolder = folder;
        }

        public string FolderName
        {
            get => _currentFolder.DirectoryInfo.Name;
        }

        public void AddNode(FolderBaseData folder)
        {
            var subNodePath = folder.DirectoryInfo.Parent!.FullName;

            if (subNodePath != _currentFolder.DirectoryInfo.FullName)
                throw new OperationCanceledException($"Папка по адресу {subNodePath} не является дочерней по отношению к текущей");

            _subNodes.Add(folder.DirectoryInfo.Name, new FileTreeNode(folder));
        }

        public void AddFile(FileBaseData file)
        {
            var filePath = file.FileInfo.Directory!.FullName;

            if (filePath != _currentFolder.DirectoryInfo.FullName)
                throw new OperationCanceledException($"Папка по адресу {filePath} не является дочерней по отношению к текущей");

            _files.Add(file.FileInfo.Name, file);
        }
    }
}
