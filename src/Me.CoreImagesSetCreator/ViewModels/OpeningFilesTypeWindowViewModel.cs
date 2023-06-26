using Me.CoreImagesSetCreator.Domain.Service;
using Me.CoreImagesSetCreator.Domain.ValueObjects;
using Me.CoreImagesSetCreator.Infrastructure.FilesChoose;
using Me.CoreImagesSetCreator.Infrastructure.FilesMine;
using Me.CoreImagesSetCreator.Infrastructure.FilesMine.FilesSearch;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Diagnostics;

namespace Me.CoreImagesSetCreator.ViewModels
{
    public class OpeningFilesTypeWindowViewModel : BindableBase, IDialogAware
    {
        private readonly IFilesMinerService _filesMinerService;
        private readonly FilesSearchOptionsBuilder _filesSearchOptionsBuilder;

        private FolderContentContainer _contentContainer = null!;

        public OpeningFilesTypeWindowViewModel(IFilesMinerService minerService, FilesSearchOptionsBuilder searchOptionsBuilder)
        {
            _filesMinerService = minerService;
            _filesSearchOptionsBuilder = searchOptionsBuilder;
        }

        public string Title => "Выбор типа загружаемых файлов";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            // ignore
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            // ignore
        }

        public DelegateCommand<DataType?> ChooseFolderCommand
        {
            get => new (AddFilesFromFolder);
        }

        public DelegateCommand AcceptChoosedFilesCommand
        {
            get => new(AcceptChoosedFiles);
        }

        private void AddFilesFromFolder(DataType? dataType)
        {
            if (dataType is null) throw new ArgumentNullException("Не выбран тип файлов");

            CommonOpenFileDialog dialog = new()
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Debug.Print(dialog.FileName);

                var searchOptions = _filesSearchOptionsBuilder.Build();
                var initFolderData = new FolderBaseData(dialog.FileName);

                // читаем все файлы с нужным разрешением по данному пути
                _contentContainer = new FolderContentContainer(initFolderData, _filesMinerService, searchOptions);
            }
        }

        private void AcceptChoosedFiles()
        {
            var dataToTransfer = new DialogParameters();
            dataToTransfer.Add($"{nameof(FolderContentContainer)}", _contentContainer);

            // передача данных в главное окно
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, dataToTransfer));
        }
    }
}
