using Me.CoreImagesSetCreator.Domain.Service;
using EnumDataType = Me.CoreImagesSetCreator.Domain.Service.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Me.CoreImagesSetCreator.Domain.FilesReflections.LazyStream;

namespace Me.CoreImagesSetCreator.Domain.DataContainer
{
    /// <summary>
    /// Класс для хранения делегатов с потоками изображений для дальнейшей работы с изображениями
    /// </summary>
    internal class ImagesContainer : DataContainerBase
    {
        internal ImagesContainer(IEnumerable<IStream> streamLaunchers) : base(streamLaunchers) { }

        internal override DataType DataType => EnumDataType.Image;
    }
}
