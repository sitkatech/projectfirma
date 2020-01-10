using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models.ReportTemplate.Models
{
    public class ReportTemplateBaseViewModel 
    {
        public string ReportTitle { get; set; }
        public dynamic ReportModel { get; set; }
    }
}