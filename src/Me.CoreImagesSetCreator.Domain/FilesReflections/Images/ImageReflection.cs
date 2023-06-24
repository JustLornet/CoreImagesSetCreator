using Me.CoreImagesSetCreator.Domain.ValueObjects;
using System.Drawing;
using Me.CoreImagesSetCreator.Domain.Service;

namespace Me.CoreImagesSetCreator.Domain.FileReflections.Images
{
    public sealed class ImageReflection : FileBase, IImageContainer, IDisposable
    {
        private readonly Bitmap _image;
        private readonly ImageType _imageType;

        internal ImageReflection(Stream imageData) : base(imageData, DataType.Image)
        {
            _image = new Bitmap(imageData);

            //TODO: Реализовать выбор image type через разбиение изображения и определения основных цветов
        }

        public Bitmap Image => _image;

        public void Dispose()
        {
            _image.Dispose();
        }
    }
}
