using Me.CoreImagesSetCreator;
using Me.CoreImagesSetCreator.DataAccess;
using Me.CoreImagesSetCreator.Domain.FilesReflections;
using Me.CoreImagesSetCreator.Domain.Service;
using Me.CoreImagesSetCreator.Domain.ValueObjects;
using Me.CoreImagesSetCreator.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;

// DI контейнер
Container container = new();

// регистрация зависимостей для контейнера
container.Register(typeof(IFilesCopyService), typeof(FilesInDocumentsCopier));
container.Register(typeof(IFilesMinerService), typeof(SimpleFilesMinerService));

// взаимодействие с пользователем через консоль
Console.WriteLine("Аллоха, пользователь!");
var folderWithImagesLocation = ReadWriteOperations.ReadFolderLocation("до папки с изображениями");
var folderWithReportsLocation = ReadWriteOperations.ReadFolderLocation("до папки с отчетами");
Console.WriteLine("Поздравляю, пользователь, дальше дело за мной!");

// получение файлов
var filesMiner = container.GetInstance<IFilesMinerService>();
// получение изображений
var getImagesTask = Task.Run(() => filesMiner.GetAllFiles(folderWithImagesLocation));
// получение отчетов
var getReportsTask = Task.Run(() => filesMiner.GetAllFiles(folderWithReportsLocation));

// копирование исходников
var filesCopier = container.GetInstance<IFilesCopyService>();
// копирование изображений
filesCopier.CopyFiles(getImagesTask.Result, DataType.Image, out var imagesStreams);
// копирование отчетов
filesCopier.CopyFiles(getReportsTask.Result, DataType.Report, out var reportsStreams);

// инициализация контейнера для работы с файлами + первоначальная обработка этих файлов внутри контейнера
