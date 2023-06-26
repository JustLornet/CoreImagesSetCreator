using Me.CoreImagesSetCreator.Domain.Service;

namespace Me.CoreImagesSetCreator.Domain.ValueObjects
{
    public sealed class FileBaseData
    {
        private readonly FileInfo _fileInfo;
        private readonly FileExtension _extension;

        public FileBaseData(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException(nameof(path));

            _fileInfo ??= new FileInfo(path);

            // чтение типа файла по разрешению
            _extension = new FileExtension(_fileInfo.Extension);
        }

        public FileBaseData(FileInfo file) : this(file.FullName)
        {
            _fileInfo = file;
        }

        public FileInfo FileInfo
        {
            get => _fileInfo;
        }

        public DataType DataType => _extension.DataType;

        public FileExtension Extension => _extension;

        public string Name => _fileInfo.Name;

        public string FullName => _fileInfo.FullName;
    }
}
