using Me.CoreImagesSetCreator.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Me.CoreImagesSetCreator.Domain.Service;

namespace Me.CoreImagesSetCreator.Domain.FileReflections.Reports
{
    internal sealed class ReportReflection : FileBase, IReportContainer
    {
        internal ReportReflection(Stream reportData) : base(reportData, DataType.Table) { }
    }
}
