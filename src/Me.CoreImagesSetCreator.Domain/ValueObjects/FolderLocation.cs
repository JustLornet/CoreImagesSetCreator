using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Me.CoreImagesSetCreator.Domain.ValueObjects
{
    public sealed class FolderLocation
    {
        private string _fullPath = string.Empty;
        private DirectoryInfo _directoryInfo = null!;

        public FolderLocation(string path)
        {
            FullPath = path;
        }

        public string FullPath
        {
            get
            {
                return _fullPath;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(FullPath));

                if (!IsFolderExists(value))
                    throw new DirectoryNotFoundException(nameof(FullPath));

                _fullPath = value;
            }
        }

        public DirectoryInfo DirectoryInfo
        {
            get
            {
                _directoryInfo ??= new DirectoryInfo(_fullPath);

                return _directoryInfo;
            }
        }

        //public AuthorizationRuleCollection AccessRules
        //{
        //    get
        //    {
        // TODO: не работает - дописать
        //        var access = DirectoryInfo.GetAccessControl();

        //        return access.GetAccessRules(false, false, typeof(NTAccount));
        //    }
        //}

        //public IEnumerable<AuthorizationRule> ActualUserAccessRules
        //{
        //    get
        //    {
        // TODO: не работает - дописать
        //        var userName = WindowsIdentity.GetCurrent().Name;

        //        foreach(AuthorizationRule rule in AccessRules)
        //        {
        //            if (rule.IdentityReference.Value.Equals(userName, StringComparison.CurrentCultureIgnoreCase))
        //            {
        //                yield return rule;
        //            }
        //        }
        //    }
        //}

        public static bool IsFolderExists(string folderPath)
        {
            return Directory.Exists(folderPath);
        }
    }
}
