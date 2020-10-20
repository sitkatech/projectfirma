using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ReportTemplates.Models
{
    public class ReportTemplateTechnicalAssistanceRequestModel
    {
        public int FiscalYear { get; set; }
        public ReportTemplatePersonModel AssignedPerson { get; set; }
        public string Type { get; set; }
        public int? HoursRequested { get; set; }
        public int? HoursAllocated { get; set; }
        public int? HoursProvided { get; set; }
        public string Notes { get; set; }
        public decimal DollarValueDecimal { get; set; }
        public string DollarValueString { get; set; }

        public ReportTemplateTechnicalAssistanceRequestModel(TechnicalAssistanceRequest technicalAssistanceRequest,
            List<TechnicalAssistanceParameter> assistanceParameters)
        {
            FiscalYear = technicalAssistanceRequest.FiscalYear;
            AssignedPerson = new ReportTemplatePersonModel(technicalAssistanceRequest.Person);
            Type = technicalAssistanceRequest.TechnicalAssistanceType.TechnicalAssistanceTypeDisplayName;
            HoursRequested = technicalAssistanceRequest.HoursRequested;
            HoursAllocated = technicalAssistanceRequest.HoursAllocated;
            HoursProvided = technicalAssistanceRequest.HoursProvided;
            Notes = technicalAssistanceRequest.Notes;
            DollarValueDecimal = technicalAssistanceRequest.GetValueProvided(assistanceParameters);
            DollarValueString = DollarValueDecimal.ToStringCurrency();
        }
    }
}