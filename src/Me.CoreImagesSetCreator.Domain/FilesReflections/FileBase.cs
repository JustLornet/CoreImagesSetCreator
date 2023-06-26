using Me.CoreImagesSetCreator.Domain.Service;
using Me.CoreImagesSetCreator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Domain.FileReflections
{
    public abstract class FileBase
    {
        protected readonly Stream _fileData;
        private readonly DataType _fileType;

        internal FileBase (Stream fileData, DataType fileType)
        {
            _fileData = fileData;
            _fileType = fileType;
        }

        internal DataType FileType
        {
            get => _fileType;
        }
    }
}
