using Me.CoreImagesSetCreator.Domain.FilesReflections.LazyStream;
using Me.CoreImagesSetCreator.Domain.Service;
using Me.CoreImagesSetCreator.Domain.ValueObjects;

namespace Me.CoreImagesSetCreator.Infrastructure
{
    /// <summary>
    /// Временная реализация для сохранения в папку документы, далее - сделать через бд
    /// </summary>
    public sealed class FilesInDocumentsCopier : IFilesCopyService
    {
        /// <summary>
        /// Сохранение + проверка существования папки с документами и создание её, если есть
        /// </summary>
        /// <param name="filesToSave">Файлы, которые необходимо сохранить</param>
        public void CopyFiles(IEnumerable<FileLocation> filesToSave, DataType fileType, out IList<IStream> streamCreator)
        {
            // TODO: нарушение SRP - перенести проверку и создание папки в отдельную логику
            // папка для сохранения фото в документах
            var documentFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CoreImagesHandling");

            streamCreator = new List<IStream>(filesToSave.Count());

            documentFolder = (fileType) switch
            {
                DataType.Image => Path.Combine(documentFolder, "Images"),
                DataType.Table => Path.Combine(documentFolder, "Reports"),
                _ => Path.Combine(documentFolder, "NI"),
            };

            // проверка, что папку существует
            var isDirectoryExists = Directory.Exists(documentFolder);

            if (!isDirectoryExists)
            {
                Directory.CreateDirectory(documentFolder);
            }

            foreach (var file in filesToSave)
            {
                // зашиваем путь до файла в имя файла
                var initPath = (string)file.FullPath.Replace("\\", "--");
                initPath = (string)initPath.Replace(":", "---");

                var destFileName = $"{documentFolder}\\{initPath}";
                File.Copy(file.FullPath, destFileName, true);

                //TODO: нарушение SRP - перенести фунцию заполнения
                streamCreator.Add(new StreamAdapter(() => new FileStream(destFileName, FileMode.Open)));
            }
        }
    }
}
