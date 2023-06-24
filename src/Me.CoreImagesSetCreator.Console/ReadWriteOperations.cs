using Me.CoreImagesSetCreator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator
{
    /// <summary>
    /// Для общения с пользователем через консоль
    /// </summary>
    internal static class ReadWriteOperations
    {
        /// <summary>
        /// Чтение пути, введенного пользователем, и если путь верный, дальше идет работа с ним
        /// </summary>
        /// <param name="dummyCounter">Если путь неверный, данный метод вызывается рекурсивно с новым сообщением пользователю</param>
        /// <param name="destinationPointer">Приписка о том, на что необходимо указать путь: полный путь [destinationPointer]</param>
        /// <returns>Путь до папки, обернутый в тип</returns>
        internal static FolderLocation ReadFolderLocation(string destinationPointer, uint dummyCounter = 0)
        {
            var messageForUser = dummyCounter switch
            {
                0 => $"Введи полный путь {destinationPointer}:",
                1 => $"По данному пути не существует папки. Введи корректный путь {destinationPointer}:",
                2 => $"И снова там нет папки... Попытайся ещё раз, тебе нужно указать путь {destinationPointer}:",
                3 => "Попробуй открыть в проводнике и убедись, что там нет папки. Ещё раз:",
                > 3 => "Тебе уже ничем не помочь... Пытайся, пока мой стек не переполнится, так как данная операция - рекурсивна:"
            };

            Console.WriteLine(messageForUser);
            var iniImagesFolderPath = Console.ReadLine();
            FolderLocation folderLocation;

            try
            {
                folderLocation = new FolderLocation(iniImagesFolderPath);

                // TODO: реализовать проверку доступа на чтение
            }
            catch
            {
                folderLocation = ReadFolderLocation(destinationPointer, ++dummyCounter);
            }

            return folderLocation;
        }
    }
}
