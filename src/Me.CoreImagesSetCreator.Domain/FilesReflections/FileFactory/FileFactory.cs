using Me.CoreImagesSetCreator.Domain.FileReflections;
using Me.CoreImagesSetCreator.Domain.FileReflections.Images;
using Me.CoreImagesSetCreator.Domain.FileReflections.Reports;
using Me.CoreImagesSetCreator.Domain.Service;
using Me.CoreImagesSetCreator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Domain.FilesReflections.FileFactory
{
    /// <summary>
    /// Фабрика файлов, используется только внутри стрителя файлов(FileBuilder)
    /// </summary>
    internal static class FileFactory
    {
        private static Dictionary<DataType, Func<Stream, FileBase>> _filesCreatorContainer = new()
        {
            { DataType.Image, (data) => new ImageReflection(data) },
            { DataType.Table, (data) => new ReportReflection(data) },
        };

        internal static FileBase GetFile(Stream fileData, DataType fileType)
        {
            if (!_filesCreatorContainer.ContainsKey(fileType))
                throw new NotImplementedException($"Отсутствует реализация {fileType.GetType().FullName}");

            return _filesCreatorContainer[fileType](fileData);
        }
    }
}
