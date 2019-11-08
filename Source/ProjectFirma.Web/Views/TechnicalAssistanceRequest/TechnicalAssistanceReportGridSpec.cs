using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.TechnicalAssistanceRequest
{
    public class TechnicalAssistanceReportGridSpec : GridSpec<ProjectFirmaModels.Models.TechnicalAssistanceRequest>
    {
        public TechnicalAssistanceReportGridSpec(FirmaSession currentFirmaSession, List<TechnicalAssistanceParameter> technicalAssistanceParameters)
        {
            var isAdmin = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            if (isAdmin)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), 1000, "Edit Technical Assistance Requests for this Project")), 30, DhtmlxGridColumnFilterType.None);
            }
            Add("Fiscal Year", x => x.FiscalYear.ToString(), 45, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Project Name", x => UrlTemplate.MakeHrefString(x.Project.GetDetailUrl(), x.Project.ProjectName), 300, DhtmlxGridColumnFilterType.Text);
            Add("Lead Implementer", x => x.Project.GetPrimaryContactOrganization().GetDisplayName(), 240, DhtmlxGridColumnFilterType.Text);
            Add("Assistance Type", x => x.TechnicalAssistanceType.TechnicalAssistanceTypeDisplayName, 110, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Person Requested", x => x.Person?.GetFullNameFirstLast(), 110, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Hours Requested", x => x.HoursRequested.ToString(), 75, DhtmlxGridColumnFilterType.Text);
            Add("Hours Allocated", x => x.HoursAllocated.ToString(), 75, DhtmlxGridColumnFilterType.Text);
            Add("Hours Provided", x => x.HoursProvided.ToString(), 75, DhtmlxGridColumnFilterType.Text);
            Add("Value of Technical Assistance Provided", x => x.GetValueProvided(technicalAssistanceParameters).ToStringCurrency(), 95, DhtmlxGridColumnFilterType.Text);
            Add("Notes", x => x.Notes, 300, DhtmlxGridColumnFilterType.Text);
        }
    }
}
