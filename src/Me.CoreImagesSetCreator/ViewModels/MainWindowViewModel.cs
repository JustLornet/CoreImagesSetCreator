using MahApps.Metro.Controls;
using Me.CoreImagesSetCreator.Domain.ValueObjects;
using Me.CoreImagesSetCreator.Infrastructure.FilesChoose;
using Me.CoreImagesSetCreator.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Me.CoreImagesSetCreator.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IDialogService _dialogService;

        private List<FolderContentContainer> _folderContentContainer = new();

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
        }

        public DelegateCommand<MainWindow> OpenFilesCommand
        {
            get => new DelegateCommand<MainWindow>(OpenFilesTypeWindow);
        }

        private void OpenFilesTypeWindow(MainWindow mainWindow)
        {
            _dialogService.ShowDialog("OpeningFilesTypeWindow", SaveDataFromFilesTypeWindow);
        }

        /// <summary>
        /// Получение результатов выбор папки пользователем
        /// </summary>
        /// <param name="dialogResult"></param>
        private void SaveDataFromFilesTypeWindow(IDialogResult dialogResult)
        {
            if (dialogResult.Result is ButtonResult.OK)
            {
                if (dialogResult.Parameters.ContainsKey(nameof(FolderContentContainer)))
                    _folderContentContainer.Add(dialogResult.Parameters.GetValue<FolderContentContainer>(nameof(FolderContentContainer)));
            }
        }
    }
}
