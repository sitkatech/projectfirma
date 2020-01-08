//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReportTemplateModelType]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ReportTemplateModelType GetReportTemplateModelType(this IQueryable<ReportTemplateModelType> reportTemplateModelTypes, int reportTemplateModelTypeID)
        {
            var reportTemplateModelType = reportTemplateModelTypes.SingleOrDefault(x => x.ReportTemplateModelTypeID == reportTemplateModelTypeID);
            Check.RequireNotNullThrowNotFound(reportTemplateModelType, "ReportTemplateModelType", reportTemplateModelTypeID);
            return reportTemplateModelType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReportTemplateModelType(this IQueryable<ReportTemplateModelType> reportTemplateModelTypes, List<int> reportTemplateModelTypeIDList)
        {
            if(reportTemplateModelTypeIDList.Any())
            {
                reportTemplateModelTypes.Where(x => reportTemplateModelTypeIDList.Contains(x.ReportTemplateModelTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReportTemplateModelType(this IQueryable<ReportTemplateModelType> reportTemplateModelTypes, ICollection<ReportTemplateModelType> reportTemplateModelTypesToDelete)
        {
            if(reportTemplateModelTypesToDelete.Any())
            {
                var reportTemplateModelTypeIDList = reportTemplateModelTypesToDelete.Select(x => x.ReportTemplateModelTypeID).ToList();
                reportTemplateModelTypes.Where(x => reportTemplateModelTypeIDList.Contains(x.ReportTemplateModelTypeID)).Delete();
            }
        }

        public static void DeleteReportTemplateModelType(this IQueryable<ReportTemplateModelType> reportTemplateModelTypes, int reportTemplateModelTypeID)
        {
            DeleteReportTemplateModelType(reportTemplateModelTypes, new List<int> { reportTemplateModelTypeID });
        }

        public static void DeleteReportTemplateModelType(this IQueryable<ReportTemplateModelType> reportTemplateModelTypes, ReportTemplateModelType reportTemplateModelTypeToDelete)
        {
            DeleteReportTemplateModelType(reportTemplateModelTypes, new List<ReportTemplateModelType> { reportTemplateModelTypeToDelete });
        }
    }
}