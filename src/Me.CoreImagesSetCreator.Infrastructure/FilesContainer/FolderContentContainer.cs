using Me.CoreImagesSetCreator.Domain.ValueObjects;
using Me.CoreImagesSetCreator.Infrastructure.FilesMine;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Infrastructure.FilesChoose
{
    /// <summary>
    /// Хранение информации о выбранной папке и всех вложенных в нее файлов, подходящих условиям выбора
    /// </summary>
    public class FolderContentContainer
    {
        private readonly FolderBaseData _folderData;
        private readonly IFilesMinerService _minerService;
        private readonly IFilesSearchOptions _filesSearchOptions;
        private IEnumerable<FileBaseData> _files = null!;

        public FolderContentContainer(FolderBaseData folder, IFilesMinerService filesMiner, IFilesSearchOptions searchOptions)
        {
            _folderData = folder;
            _minerService = filesMiner;
            _filesSearchOptions = searchOptions;
        }

        public async Task FindMatchingFiles()
        {
            _files = await _minerService.GetFiles(_folderData, _filesSearchOptions);
            
        }

        public IEnumerable<FileBaseData> Files
        {
            get => _files ?? throw new NullReferenceException($"Список файлов пуст, выполните команду {nameof(FindMatchingFiles)}");
        }
    }
}
