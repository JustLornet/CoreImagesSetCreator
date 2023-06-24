using Me.CoreImagesSetCreator.Domain.Service;
using Me.CoreImagesSetCreator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Domain.FileContainers
{
    public abstract class FilesContainerBase<TFile> : IDisposable where TFile : IDisposable
    {
        private IEnumerable<TFile> _files;
        private readonly FileType _fileType;

        public FilesContainerBase(FileType fileType)
        {
            _fileType = fileType;
        }

        public FilesContainerBase(FileType fileType, IEnumerable<TFile> )

        public IEnumerable<TFile> Files { get; }

        public FileType FileType { get; }

        public void Dispose()
        {
            foreach(var file in _files)
            {
                file.Dispose();
            }
        }
    }
}
