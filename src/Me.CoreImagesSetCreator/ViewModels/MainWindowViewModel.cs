using MahApps.Metro.Controls;
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

namespace Me.CoreImagesSetCreator.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IDialogService _dialogService;

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
        }

        public DelegateCommand<MainWindow> OpenFilesCommand
        {
            get => new DelegateCommand<MainWindow>(OpenFilesTypeWindow);
        }

        private void OpenFilesTypeWindow (MainWindow mainWindow)
        {
            _dialogService.ShowDialog("OpeningFilesTypeWindow");
        }
    }
}
