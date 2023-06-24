using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Domain.FilesReflections.LazyStream
{
    /// <summary>
    /// Обертка, чтобы можно было запускать поток отложенно для обработки по одному файлу
    /// </summary>
    public sealed class StreamAdapter : IStream
    {
        private readonly Func<Stream> _streamCreator;

        public StreamAdapter(Func<Stream> initStream)
        {
            _streamCreator = initStream;
        }

        Stream IStream.GetStream()
        {
            using (var stream = _streamCreator())
            {
                return stream;
            }
        }
    }
}
