using Me.CoreImagesSetCreator.Domain.FileReflections;
using Me.CoreImagesSetCreator.Domain.Service;
using Me.CoreImagesSetCreator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Domain.FilesReflections.FileFactory
{
    public sealed class FileBuilder
    {
        private Stream _fileData;
        private DataType _type;

        public FileBuilder SetStream(Stream fileData)
        {
            _fileData = fileData;

            return this;
        }

        public FileBuilder SetFileType(DataType fileType)
        {
            _type = fileType;

            return this;
        }

        public FileBase Build()
        {
            if (_fileData is null)
                throw new ArgumentNullException(nameof(_fileData));

            if (_type is DataType.None)
                throw new ArgumentOutOfRangeException(nameof(_type));

            return FileFactory.GetFile(_fileData, _type);
        }
    }
}
