//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReportTemplate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ReportTemplate GetReportTemplate(this IQueryable<ReportTemplate> reportTemplates, int reportTemplateID)
        {
            var reportTemplate = reportTemplates.SingleOrDefault(x => x.ReportTemplateID == reportTemplateID);
            Check.RequireNotNullThrowNotFound(reportTemplate, "ReportTemplate", reportTemplateID);
            return reportTemplate;
        }

    }
}