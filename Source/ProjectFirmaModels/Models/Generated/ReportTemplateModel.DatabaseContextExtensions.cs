//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReportTemplateModel]
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
        public static ReportTemplateModel GetReportTemplateModel(this IQueryable<ReportTemplateModel> reportTemplateModels, int reportTemplateModelID)
        {
            var reportTemplateModel = reportTemplateModels.SingleOrDefault(x => x.ReportTemplateModelID == reportTemplateModelID);
            Check.RequireNotNullThrowNotFound(reportTemplateModel, "ReportTemplateModel", reportTemplateModelID);
            return reportTemplateModel;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReportTemplateModel(this IQueryable<ReportTemplateModel> reportTemplateModels, List<int> reportTemplateModelIDList)
        {
            if(reportTemplateModelIDList.Any())
            {
                reportTemplateModels.Where(x => reportTemplateModelIDList.Contains(x.ReportTemplateModelID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReportTemplateModel(this IQueryable<ReportTemplateModel> reportTemplateModels, ICollection<ReportTemplateModel> reportTemplateModelsToDelete)
        {
            if(reportTemplateModelsToDelete.Any())
            {
                var reportTemplateModelIDList = reportTemplateModelsToDelete.Select(x => x.ReportTemplateModelID).ToList();
                reportTemplateModels.Where(x => reportTemplateModelIDList.Contains(x.ReportTemplateModelID)).Delete();
            }
        }

        public static void DeleteReportTemplateModel(this IQueryable<ReportTemplateModel> reportTemplateModels, int reportTemplateModelID)
        {
            DeleteReportTemplateModel(reportTemplateModels, new List<int> { reportTemplateModelID });
        }

        public static void DeleteReportTemplateModel(this IQueryable<ReportTemplateModel> reportTemplateModels, ReportTemplateModel reportTemplateModelToDelete)
        {
            DeleteReportTemplateModel(reportTemplateModels, new List<ReportTemplateModel> { reportTemplateModelToDelete });
        }
    }
}