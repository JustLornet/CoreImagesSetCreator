using Me.CoreImagesSetCreator.Domain.Service;
using Me.CoreImagesSetCreator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Infrastructure.Service
{
    public static class ExtensionsContainer
    {
        private static readonly HashSet<string> ImageExts = new() { "PNG", "APNG", "AVIF", "GIF", "JPEG", "JPG", "SVG", "WebP", "BMP", "ICO", "TIFF" };
        private static readonly HashSet<string> DocumentExts = new() { "DOC", "DOCM", "DOCX", "DOT", "TXT" };
        private static readonly HashSet<string> TableExts = new() { "XLS", "XLSX", "CSV" };

        public static readonly Dictionary<DataType, HashSet<string>> Extensions = new()
        {
            { DataType.Image, ImageExts },
            { DataType.Document, DocumentExts },
            { DataType.Table, TableExts },
        };
    }
}
