using Me.CoreImagesSetCreator.Domain.Service;

namespace Me.CoreImagesSetCreator.Domain.ValueObjects
{
    public sealed class FileLocation
    {
        private readonly string _fullPath;
        private readonly FileInfo _fileInfo;

        public FileLocation(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException(nameof(path));

            _fullPath = path;

            _fileInfo ??= new FileInfo(path);
        }

        public FileLocation(FileInfo file) : this(file.FullName)
        {
            _fileInfo = file;
        }

        public string FullPath
        {
            get => _fullPath;
        }

        public FileInfo FileInfo
        {
            get => _fileInfo;
        }
    }
}
