using MahApps.Metro.Controls;
using Me.CoreImagesSetCreator.Infrastructure.FilesMine;
using Me.CoreImagesSetCreator.ViewModels;
using Me.CoreImagesSetCreator.Views;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Me.CoreImagesSetCreator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override MetroWindow CreateShell()
        {
            return Container.Resolve<MainWindow>("MainWindow");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // единственный экземпляр главного окна
            containerRegistry.Register<MainWindow>("MainWindow");
            // окно с выбором типа загружаемых файлов
            containerRegistry.RegisterDialog<OpeningFilesTypeWindow, OpeningFilesTypeWindowViewModel>();
            // сервис для поиска и сохранения (в рамках процесса) данных об анализируемых файлов
            containerRegistry.Register<IFilesMinerService, SimpleFilesMinerService>();
        }
    }
}
