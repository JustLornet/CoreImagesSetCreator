using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Infrastructure.FilesMine.FilesSearch
{
    internal class SearchOptionsNullObject : IFilesSearchOptions
    {
        public bool IsFileMatch(FileInfo fileLocation)
        {
            return true;
        }
    }
}
