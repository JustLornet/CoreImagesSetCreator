using Me.CoreImagesSetCreator.Domain.Service;
using Me.CoreImagesSetCreator.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Domain.ValueObjects
{
    public sealed class FileExtension
    {
        private string _extension;
        private bool _isExtensionValid = false;
        private DataType _dataType = DataType.None;

        public FileExtension(string extension)
        {
            _extension = extension.ToUpper();

            CheckExtension(_extension);
        }

        public FileExtension(ReadOnlySpan<char> extension) : this(extension.ToString()) { }

        public bool IsExtensionValid { get => _isExtensionValid; }

        public DataType DataType { get => _dataType; }

        private void CheckExtension(string extension)
        {
            foreach(var pair in ExtensionsContainer.Extensions)
            {
                bool isExists = pair.Value.Contains(extension);

                if(isExists)
                {
                    _isExtensionValid = true;
                    _dataType = pair.Key;
                    break;
                }
            }
        }
    }
}
