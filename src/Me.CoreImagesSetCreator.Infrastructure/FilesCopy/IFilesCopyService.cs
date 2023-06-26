using Me.CoreImagesSetCreator.Domain.Service;
using Me.CoreImagesSetCreator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Me.CoreImagesSetCreator.Domain.FilesReflections.LazyStream;

namespace Me.CoreImagesSetCreator.Infrastructure.FilesCopy
{
    /// <summary>
    /// Интертфейс для пересохранения файлов, чтобы не работать с исходниками
    /// </summary>
    public interface IFilesCopyService
    {
        /// <summary>
        /// Копирование файлов выбранным способом - либо в файловую систему, либо в бд
        /// </summary>
        /// <param name="filesToSave">Информация по файлам, которые необходимо скопировать</param>
        /// <param name="fileType">Типы файлов, которые копируются. На основании этого параметра определеяем куда копировать</param>
        /// <param name="data">Обертка для стрима для дальнейшего чтения файлов. Необходимо самому определять в корне композиции в зависимости от того способа, куда сохраняются файлы</param>
        // data выполнена через out, т.к. по смыслу функция копирования может возвращать только bool, говорящий об успешности операции
        public void CopyFiles(IEnumerable<FileBaseData> filesToSave, DataType fileType, out IList<IStream> data);
    }
}
