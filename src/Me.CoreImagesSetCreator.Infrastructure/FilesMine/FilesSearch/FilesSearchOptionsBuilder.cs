using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Infrastructure.FilesMine.FilesSearch
{
    /// <summary>
    /// Настройка опций для поиска файлов, выполняемая пользователем
    /// </summary>
    public sealed class FilesSearchOptionsBuilder
    {
        public IFilesSearchOptions Build()
        {
            //TODO: на данном этапе сделано заглушкой
            return new SearchOptionsNullObject();
        }

        // Очистка всех установленных значений
        public void Clear()
        {
            // ignore
        }
    }
}
