using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeType
{
    public class ManageViewData : FirmaViewData
    {
        public ProjectCustomAttributeTypeGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public string NewProjectCustomAttributeTypeUrl { get; }
        public bool HasManagePermissions { get; }
        public string EditSortOrderUrl { get; }

        public ManageViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage neptunePage)
            : base(currentPerson, neptunePage)
        {
            EntityName = "Attribute Type";
            PageTitle = $"Manage {FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabelPluralized()}";

            NewProjectCustomAttributeTypeUrl = SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(t => t.New());
            GridSpec = new ProjectCustomAttributeTypeGridSpec()
            {
                ObjectNameSingular = "Attribute Type",
                ObjectNamePlural = "Attribute Types",
                SaveFiltersInCookie = true
        };

            GridName = "projectCustomAttributeTypeGrid";
            GridDataUrl = SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(tc => tc.ProjectCustomAttributeTypeGridJsonData());

            EditSortOrderUrl = SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(x => x.EditSortOrder());
            
            HasManagePermissions = new FirmaAdminFeature().HasPermissionByPerson(CurrentPerson);
        }

        
    }
}
