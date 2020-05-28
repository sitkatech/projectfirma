using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectStatus
{
    public class ManageViewData : FirmaViewData
    {
        public ProjectStatusGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public string NewProjectStatusUrl { get; }
        public bool HasManagePermissions { get; }
        public string EditSortOrderUrl { get; }

        public ManageViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage neptunePage)
            : base(currentFirmaSession, neptunePage)
        {
            var fieldDefinitionLabelProject = FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel();
            var fieldDefinitionForStatus = FieldDefinitionEnum.Status.ToType();
            var statusLabelPluralized =
                fieldDefinitionForStatus.GetFieldDefinitionLabel()
                    .Equals("Status", StringComparison.InvariantCultureIgnoreCase)
                    ? "Statuses"
                    : fieldDefinitionForStatus.GetFieldDefinitionLabelPluralized();
            EntityName = $"{fieldDefinitionLabelProject} {fieldDefinitionForStatus.GetFieldDefinitionLabel()}";
            PageTitle = $"{fieldDefinitionLabelProject} {statusLabelPluralized}";

            NewProjectStatusUrl = SitkaRoute<ProjectStatusController>.BuildUrlFromExpression(t => t.New());
            GridSpec = new ProjectStatusGridSpec()
            {
                ObjectNameSingular = "Attribute Type",
                ObjectNamePlural = "Attribute Types",
                SaveFiltersInCookie = true
            };

            GridName = "projectStatusGrid";
            GridDataUrl = SitkaRoute<ProjectStatusController>.BuildUrlFromExpression(x => x.ProjectStatusGridJsonData());

            EditSortOrderUrl = SitkaRoute<ProjectStatusController>.BuildUrlFromExpression(x => x.EditSortOrder());
            
            HasManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
        }

        
    }
}
