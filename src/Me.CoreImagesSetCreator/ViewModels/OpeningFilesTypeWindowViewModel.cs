using Me.CoreImagesSetCreator.Domain.Service;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.ViewModels
{
    public class OpeningFilesTypeWindowViewModel : BindableBase, IDialogAware
    {
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
                // читаем все файлы с нужным разрешением по данному пути
            }
        }
    }
}
