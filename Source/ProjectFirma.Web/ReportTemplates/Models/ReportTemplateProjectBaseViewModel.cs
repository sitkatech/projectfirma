using System.Collections.Generic;

namespace ProjectFirma.Web.ReportTemplates.Models
{
    public class ReportTemplateProjectBaseViewModel 
    {
        public string ReportTitle { get; set; }
        public List<ReportTemplateProjectModel> ReportModel { get; set; }
    }

    // Other base view models would go here if we created a new model type
}