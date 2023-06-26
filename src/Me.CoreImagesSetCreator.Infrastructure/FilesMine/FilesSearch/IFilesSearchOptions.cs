using Me.CoreImagesSetCreator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Infrastructure.FilesMine
{
    public interface IFilesSearchOptions
    {
        public bool IsFileMatch(FileInfo fileLocation);
    }
}
