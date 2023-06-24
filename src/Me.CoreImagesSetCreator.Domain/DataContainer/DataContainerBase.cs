using Me.CoreImagesSetCreator.Domain.FilesReflections.LazyStream;
using Me.CoreImagesSetCreator.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Domain.DataContainer
{
    /// <summary>
    /// Класс для хранения информации (запуск потоков через делегат) для дальнейшей работы с ней внутри ПО
    /// </summary>
    internal abstract class DataContainerBase
    {
        private readonly IEnumerable<IStream> _streamLaunchers;

        internal DataContainerBase(IEnumerable<IStream> streamLaunchers)
        {
            _streamLaunchers = streamLaunchers;
        }

        internal abstract DataType DataType { get; }

        internal virtual void Accept(IDataVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
