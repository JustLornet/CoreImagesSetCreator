using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Infrastructure.Service
{
    public static class FileExtensionHandler
    {
        public static readonly string[] ImageExts = { "PNG", "APNG", "AVIF", "GIF", "JPEG", "JPG", "SVG", "WebP", "BMP", "ICO", "TIFF" };
        public static readonly string[] DocumentExts = { "DOC", "DOCM", "DOCX", "DOT", "TXT" };
        public static readonly string[] TableExts = { "XLS", "XLSX", "CSV" };

    }
}
